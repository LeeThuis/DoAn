using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMatter : MonoBehaviour
{
    [SerializeField] Transform _enemyPosition;

    [SerializeField] TowerGunMatter _gunTowers;

    [SerializeField] LayerMask _enemyLayer;

    [SerializeField] private bool detectEnemy;

    [SerializeField] float _attackTimer = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

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

        _gunTowers.Tomato();
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
