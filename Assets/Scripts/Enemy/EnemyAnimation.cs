using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : AnimationManager
{
    Animator _enemyAnim;

    [SerializeField] SpriteRenderer _enemyRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _enemyAnim = GetComponent<Animator>();
        _enemyRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = (GameManager.Instant.BaseController.transform.position - this.transform.position).normalized;
        _enemyAnim.SetFloat("LastMoveX", dir.x);
        _enemyAnim.SetFloat("LastMoveY", dir.y);
        
        if(dir.x < 0)
        {
            _enemyRenderer.flipX = false;
        }
        else
        {
            _enemyRenderer.flipX = true;
        }
    }
}
