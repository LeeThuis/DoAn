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

    public void Init(PlayerController player)
    {
        this._player = player;
    }
    public abstract void Fire();

}
