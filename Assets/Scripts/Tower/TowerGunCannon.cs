using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGunCannon : MonoBehaviour
{
    [SerializeField] BulletBase _bullet;

    [SerializeField] Transform _enemy;
    [SerializeField] Transform _gunTower;

    [SerializeField] LayerMask _enemyPosition;

    [SerializeField] float _speed;
    [SerializeField] float _damage;
    [SerializeField] float _lifeTime;
    [SerializeField] float _radius;
    public void Cannon()
    {
        BulletBase cannon = ObjectPooling.Instant.GetComp<BulletBase>(_bullet.gameObject);
        cannon.transform.position = _gunTower.transform.position;

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

        Vector2 dir = _enemy.transform.position - cannon.transform.position;
        float rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        cannon.transform.rotation = Quaternion.Euler(0f, 0f, rot);
        cannon.Init(_speed, _damage, _lifeTime, dir.normalized);
        cannon.gameObject.SetActive(true);
    }
}
