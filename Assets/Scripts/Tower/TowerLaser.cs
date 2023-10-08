using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLaser : MonoBehaviour
{
    [SerializeField] Transform _enemyPosition;

    [SerializeField] LayerMask _enemyLayer;

    [SerializeField] float _attackCooldown;

    [SerializeField] private bool detectEnemy;

    private float _attackTimer;

    // Start is called before the first frame update
    void Start()
    {
        _attackTimer = _attackCooldown;
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (detectEnemy)
        {
            _attackTimer += Time.deltaTime;

            if (_attackTimer >= _attackCooldown)
            {
                UpdateTarget();
                _attackTimer = 0;
            }
        }
    }
    private void UpdateTarget()
    {
        if (_enemyPosition == null)
            return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
            return;

        _enemyPosition = collision.transform;
        detectEnemy = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
            return;

        _enemyPosition = collision.transform;
        detectEnemy = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _enemyPosition = null;
        detectEnemy = false;
    }
}
