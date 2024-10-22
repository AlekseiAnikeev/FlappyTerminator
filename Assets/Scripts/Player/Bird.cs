using System;
using EnemyAI;
using Interface;
using UnityEngine;

namespace Player
{
    [RequireComponent(
            typeof(BirdMover),
            typeof(BirdCollisionHandler)
        )
    ]
    public class Bird : MonoBehaviour
    {
        private BirdMover _birdMover;
        private BirdCollisionHandler _handler;
        private Cannon _cannon;

        public event Action GameOver;

        private void Awake()
        {
            _handler = GetComponent<BirdCollisionHandler>();
            _birdMover = GetComponent<BirdMover>();
            _cannon = GetComponentInChildren<Cannon>();
        }

        private void OnEnable()
        {
            _handler.CollisionDetected += ProcessCollision;
        }

        private void OnDisable()
        {
            _handler.CollisionDetected -= ProcessCollision;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _cannon.Shoot();
            }
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