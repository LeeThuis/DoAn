using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TowerGunLaser : MonoBehaviour
{
    [SerializeField] float _radius = 10f;
    [SerializeField] float _damage = 100f;

    [SerializeField] Transform _gunTown;
    [SerializeField] Transform _enemy;

    [SerializeField] float _timer = 1f;

    LineRenderer _line;

    // Start is called before the first frame update
    void Start()
    {
        _line = this.GetComponent<LineRenderer>();
       _timer *= Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        ShootLaser();
    }

    private void ShootLaser()
    {
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
            _line.enabled = true;
            _line.positionCount = 2;
            _line.SetPosition(0, _gunTown.transform.position);
            _line.SetPosition(1, _enemy.transform.position);
            _enemy.gameObject.GetComponent<IGetHit>().GetHit(_damage * _timer);
        }
        else
        {
            _line.enabled = false;
        }
    }
}
