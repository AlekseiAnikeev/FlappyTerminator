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

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Countdown(_lifeTime));
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void FixedUpdate()
    {
        transform.Translate(_direction * (_speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Detonation?.Invoke(this);
    }
    
    public void Init()
    {
        _coroutine = StartCoroutine(Countdown(_lifeTime));
    }
    
    private IEnumerator Countdown(float delay)
    {
        yield return new WaitForSeconds(delay);

        Detonation?.Invoke(this);
    }
}