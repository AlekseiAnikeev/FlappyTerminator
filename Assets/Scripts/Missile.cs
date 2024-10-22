using System;
using System.Collections;
using EnemyAI;
using Interface;
using UnityEngine;

public class Missil : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private EnemySpawner _enemySpawner;
    
    private Coroutine _coroutine;

    public event Action<Missil> Detonation;

    private void OnDestroy()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void Update()
    {
        transform.Translate(_direction * (_speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.TryGetComponent(out Enemy _))
            Destroy(collision.gameObject);*/
        
        Destroy(gameObject);
    }

    private IEnumerator Countdown(float delay)
    {
        yield return new WaitForSeconds(delay);

        RemoveToPool();
    }

    public void Init(Action<Missil> detonation)
    {
        Detonation = detonation;

        _coroutine = StartCoroutine(Countdown(_lifeTime));
    }

    private void RemoveToPool()
    {
        Detonation?.Invoke(this);
    }
}