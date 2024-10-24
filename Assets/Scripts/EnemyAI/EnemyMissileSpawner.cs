using System.Collections;
using UnityEngine;

namespace EnemyAI
{
    public class EnemyMissileSpawner : Spawner<Missil>
    {
        [SerializeField] private float _shotRepeat = 2f;

        private Coroutine _coroutine;

        private void OnEnable()
        {
            _coroutine = StartCoroutine(Spawning(_shotRepeat));
        }

        private void OnDisable()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        protected override void Spawn()
        {
            var missil = GetObject();
            missil.transform.position = GetPosition();
            missil.Init();
            missil.Detonation += RemoveObject;
        }

        private IEnumerator Spawning(float delay)
        {
            var wait = new WaitForSeconds(delay);

            while (enabled)
            {
                Spawn();

                yield return wait;
            }
        }

        private void RemoveObject(Missil missil)
        {
            missil.Detonation -= RemoveObject;

            RemoveToPool(missil);
        }
    }
}