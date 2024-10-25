using System.Collections;
using UnityEngine;

namespace EnemyAI
{
    public class EnemyWeapon : MonoBehaviour
    {
        [SerializeField] private MissileSpawner _missileSpawner;
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
    
        private void Shoot()
        {
            _missileSpawner.CreateMissil();
        }
    
        private IEnumerator Spawning(float delay)
        {
            var wait = new WaitForSeconds(delay);

            while (enabled)
            {
                Shoot();
                

                yield return wait;
            }
        }
    }
}
