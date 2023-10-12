using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunControllerBase : MonoBehaviour
{
    protected PlayerController _player;

    [SerializeField] protected float _radios;


    [SerializeField] protected GameObject _gun;

    [SerializeField] protected float _speed, _damage, _lifeTime;

    protected Vector2 movement;
    [SerializeField] protected float _timer = 1f;
    protected float _countdownTime;

    private void Start()
    {
        _countdownTime = _timer;

    }

    private void Update()
    {
        _countdownTime -= Time.deltaTime;
    }
    public void Init(PlayerController player)
    {
        this._player = player;
    }
    public abstract void Fire();
    
}
