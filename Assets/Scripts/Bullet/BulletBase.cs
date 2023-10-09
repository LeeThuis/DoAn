using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    [SerializeField] public Rigidbody2D _rb;

    [SerializeField] public float _speed, _damage, _lifeTime;

    Vector2 _movement;

    Coroutine _bulletLifeTime;

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

    private void OnEnable()
    {
        _bulletLifeTime = StartCoroutine(LifeTime());
    }
    
    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(this._lifeTime);
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

    private void OnDisable()
    {
        _rb.velocity = Vector2.zero;

        if(_bulletLifeTime != null )
        {
            StopCoroutine(_bulletLifeTime);
        }
    }

    protected abstract void Boom(GameObject target);

}
