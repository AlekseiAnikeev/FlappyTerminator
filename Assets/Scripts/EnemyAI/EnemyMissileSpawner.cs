using System.Collections;
using UnityEngine;

namespace EnemyAI
{
    public class EnemyMissileSpawner : Spawner<Missil>
    {
        [SerializeField] private float _shotRepeat = 2f;
        [SerializeField] private float _startPosition = 1.75f;

        private Coroutine _coroutine;

        private void OnEnable()
        {
            _coroutine = StartCoroutine(Countdown(_shotRepeat));
        }

        private void OnDisable()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private IEnumerator Countdown(float delay)
        {
            var wait = new WaitForSeconds(delay);

            while (enabled)
            {
                Spawn();

                yield return wait;
            }
        }

        protected override void Spawn()
        {
            var missil = GetObject();
            missil.transform.position = GetPosition();
            missil.Init(RemoveToPool);
        }

        protected override Vector3 GetPosition()
        {
            Vector3 position = transform.position;
            position.x -= _startPosition;
            return position;
        }
    }
}