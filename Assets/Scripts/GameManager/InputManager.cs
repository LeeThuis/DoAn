using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [SerializeField] Camera _camera;
    public Vector3 _mousePosition;

    [SerializeField] SpriteRenderer _sprite;
    private void Awake()
    {

    }

    private void FixedUpdate()
    {
        this.MousePosition();
    }

    public void MousePosition()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePosition.z = 0;
        _sprite.transform.position = _mousePosition;
    }
}
