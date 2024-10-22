using System;
using Interface;
using UnityEngine;

namespace EnemyAI
{
    public class Enemy : MonoBehaviour, IInteractable
    {
        public event Action<Enemy> Detonation;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            RemoveToPool();
        }

        public void Init(Action<Enemy> detonation)
        {
            Detonation = detonation;
        }
        
        private void RemoveToPool()
        {
            Detonation?.Invoke(this);
        }
    }
}