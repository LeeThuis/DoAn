using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    LastMoveX,
    LastMoveY,
}

public class AnimationManager : MonoBehaviour
{
    Animator _anim;
    public PlayerState _playerState;

    SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _anim = this.GetComponent<Animator>();
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void UpdateAnim(PlayerState playerState)
    {


        Vector3 mouse = InputManager.Instant._mousePosition;
        mouse.z = 0;
        Vector2 dir = mouse - transform.position;

        _anim.SetFloat("LastMoveX", dir.x);
        _anim.SetFloat("LastMoveY", dir.y);

        if (dir.x < 0 )
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
}
