using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowersController : MonoBehaviour
{
    [SerializeField] Transform _enemyPosition;

    [SerializeField] TowerGunCannon _gunTowers;
    
    [SerializeField] LayerMask _enemyLayer;

    [SerializeField] private bool detectEnemy;

    [SerializeField] float _attackTimer = 1f;

    private void FixedUpdate()
    {
        if (detectEnemy)
        {
            _attackTimer -= Time.deltaTime;

            if (_attackTimer <= 0)
            {
                UpdateTarget();
                _attackTimer = 1;
            }
        }
    }
    private void UpdateTarget()
    {
        if (_enemyPosition == null)
            return;

        _gunTowers.Cannon();
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
        _attackTimer = 0.5f;
    }
}
