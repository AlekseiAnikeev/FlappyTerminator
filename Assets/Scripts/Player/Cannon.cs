using UnityEngine;

namespace Player
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private PlayerMissileSpawner _missileSpawner;
        public void Shoot()
        {
            _missileSpawner.Shoot();
        }
    }
}
