using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersAnimation : AnimationManager
{
    Animator _towersAnimator;
    [SerializeField] Transform _enemy;

    [SerializeField] float _radius;

    // Start is called before the first frame update
    void Start()
    {
        _towersAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DetecEnemy();
    }

    private void DetecEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            
            if (distanceToEnemy < _radius)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;

                Vector3 dir = enemy.transform.position - this.transform.position;
                RaycastHit2D hit = Physics2D.Raycast(this.transform.position, dir, dir.magnitude);
                _towersAnimator.SetFloat("LastMoveX", dir.normalized.x);
                _towersAnimator.SetFloat("LastMoveY", dir.normalized.y);
            }
        }
    }
}
