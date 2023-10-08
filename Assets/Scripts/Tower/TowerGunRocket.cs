using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGunRocket : MonoBehaviour
{
    [SerializeField] BulletBase _bullet;

    [SerializeField] Transform _enemy;
    [SerializeField] Transform _towerGun;

    [SerializeField] LayerMask _enemyPosition;

    [SerializeField] float _speed;
    [SerializeField] float _damage;
    [SerializeField] float _lifeTime;
    [SerializeField] float _radios;

    public void Rocket()
    {
        BulletBase rocket = ObjectPooling.Instant.GetComp<BulletBase>(_bullet.gameObject);
        rocket.transform.position = _towerGun.transform.position;

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
        if (nearestEnemy != null && shortestDistance <= _radios)
        {
            _enemy = nearestEnemy.transform;
        }

        Vector2 dir = _enemy.transform.position - rocket.transform.position;
        float rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rocket.transform.rotation = Quaternion.Euler(0f, 0f, rot);
        rocket.Init(_speed, _damage, _lifeTime, dir.normalized);
        rocket.gameObject.SetActive(true);
    }
}
