using UnityEngine;

namespace Player
{
    public class PlayerMissileSpawner : Spawner<Missil>
    {
        [SerializeField] private float _startPosition;
        
        public void Shoot()
        {
            Spawn();
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