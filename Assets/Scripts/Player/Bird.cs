using System;
using EnemyAI;
using Interface;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(BirdMover), typeof(BirdCollisionHandler))]
    public class Bird : MonoBehaviour
    {
        private BirdMover _birdMover;
        private BirdCollisionHandler _handler;

        public event Action GameOver;

        private void Awake()
        {
            _handler = GetComponent<BirdCollisionHandler>();
            _birdMover = GetComponent<BirdMover>();
        }

        private void OnEnable()
        {
            _handler.CollisionDetected += ProcessCollision;
        }

        private void OnDisable()
        {
            _handler.CollisionDetected -= ProcessCollision;
        }

        private void ProcessCollision(IInteractable interactable)
        {
            switch (interactable)
            {
                case Enemy or Missil:
                case Ground or Sky:
                    GameOver?.Invoke();
                    break;
            }
        }
        
        public void Reset()
        {
            _birdMover.Reset();
        }
    }
}