using UnityEngine;

namespace Player
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private PlayerMissileSpawner _missileSpawner;
        [SerializeField] private InputReader _inputReader;

        private void OnEnable()
        {
            _inputReader.Shot += Shoot;
        }

        private void OnDisable()
        {
            _inputReader.Shot -= Shoot;
        }

        private void Shoot()
        {
            _missileSpawner.CreateMissil();
        }
    }
}
