namespace Player
{
    public class PlayerMissileSpawner : Spawner<Missil>
    {
        public void CreateMissil()
        {
            Spawn();
        }

        protected override void Spawn()
        {
            var missil = GetObject();
            missil.transform.position = GetPosition();
            missil.Init();
            missil.Detonation += RemoveObject;
        }

        private void RemoveObject(Missil missil)
        {
            missil.Detonation -= RemoveObject;
            
            RemoveToPool(missil);
        }
    }
}