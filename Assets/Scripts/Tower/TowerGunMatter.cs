using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGunMatter : MonoBehaviour
{
    [SerializeField] BulletBase _bullet;

    [SerializeField] Transform _enemy;
    [SerializeField] Transform _gunTower;

    [SerializeField] LayerMask _enemyPosition;

    [SerializeField] float _speed;
    [SerializeField] float _damage;
    [SerializeField] float _lifeTime;
    [SerializeField] float _radius;

    public void Tomato()
    {
        BulletBase tomato = ObjectPooling.Instant.GetComp<BulletBase>(_bullet.gameObject);
        tomato.transform.position = _gunTower.transform.position;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= _radius)
        {
            _enemy = nearestEnemy.transform;
        }
        //else
        //{
        //    _enemy = null;
        //}
        Vector2 dir = _enemy.transform.position - tomato.transform.position;
        float rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        tomato.transform.rotation = Quaternion.Euler(0f, 0f, rot);
        tomato.Init(_speed, _damage, _lifeTime, dir.normalized);
        tomato.gameObject.SetActive(true);
    }
}
