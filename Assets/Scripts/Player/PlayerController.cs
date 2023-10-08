using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    public Rigidbody2D _rb;

    private Vector2 _movement;

    private float dirX, dirY;

    [SerializeField] GunControllerBase _gun;

    Animator _playerAnimator;

    public void Init()
    {
        if (_gun == null)
            this._gun = this.GetComponentInChildren<GunControllerBase>();

        this._gun.Init(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _playerAnimator = this.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.Init();
        this.Atack();
    }

    private void FixedUpdate()
    {
        this.movement();
    }

    public void movement()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");

        _movement = new Vector2(dirX, dirY).normalized;
        this._rb.velocity = new Vector2(_movement.x * _speed, _movement.y * _speed);

        if (dirX != 0 || dirY != 0)
        {
            _playerAnimator.SetBool("Run", true);
        }
        else
        {
            _playerAnimator.SetBool("Run", false);
        }
    }

    private void Atack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _gun.Fire();
        }
    }
}
