using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    [SerializeField] public Rigidbody2D _rb;

    [SerializeField] public float _speed, _damage, _lifeTime;

    Vector2 _movement;

    private void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }
    public void Init(float speed, float damage, float lifeTime, Vector2 movement)
    {
        this._speed = speed;
        this._damage = damage;
        this._lifeTime = lifeTime;
        this._movement = movement;
    }
    private void Update()
    {
        this._lifeTime -= Time.deltaTime;
        if (this._lifeTime < 0)
            this.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        _rb.velocity = this._movement * _speed;
    }

    protected abstract void Boom(GameObject target);

}
