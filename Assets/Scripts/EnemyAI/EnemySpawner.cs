using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EnemyAI
{
    public class EnemySpawner : Spawner<Enemy>
    {
        [SerializeField] private int _spawnAmount = 1;
        [SerializeField] private float _repeatRate = 5f;

        private readonly float _minCoordinateValue = -3f;
        private readonly float _maxCoordinateValue = 3f;

        private Coroutine _coroutine;

        private void Start()
        {
            _coroutine = StartCoroutine(Spawning(_repeatRate));
        }

        private void OnDisable()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        protected override Vector3 GetPosition()
        {
            float coordinateY = Random.Range(_minCoordinateValue, _maxCoordinateValue);

            return new Vector3(transform.position.x, coordinateY, 0);
        }

        protected override void Spawn()
        {
            for (int i = 0; i < _spawnAmount; i++)
            {
                var enemy = GetObject();
                enemy.transform.position = GetPosition();
                enemy.Detonation += RemoveObject;
            }
        }

        private void RemoveObject(Enemy enemy)
        {
            enemy.Detonation -= RemoveObject;
            
            RemoveToPool(enemy);
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
    }
}