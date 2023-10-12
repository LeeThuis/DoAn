using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class EnemyController : EnemyManager , IGetHit
{
    [SerializeField] private Slider _slider;

    [SerializeField] float _HP = 100f;
    [SerializeField] float dmg = 50f;

    [SerializeField] public bool isActive;
    [SerializeField] float _speed = 3f;
    
    Rigidbody2D _rd;

    Animator _enemyAnimator;

    // Start is called before the first frame update
    void Awake()
    {
        _rd = this.GetComponent<Rigidbody2D>();
        _enemyAnimator = this.GetComponentInChildren<Animator>();
    }

    public void Init(float Hp, float Dmg)
    {
        this._HP = Hp;
        this.dmg = Dmg;
        
    }

    // Update is called once per frame
    void Update()
    {
        target();
    }

    public void target()
    {
        Vector2 dir = GameManager.Instant.BaseController.transform.position - this.transform.position;
        _rd.velocity = dir.normalized * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            _enemyAnimator.SetBool("explode", true);
            collision.gameObject.GetComponent<IGetHit>().GetHit(dmg);
            Invoke("SetActive", 1.5f);
        }
    }

    public void GetHit(float dmg)
    {
        this._HP -= dmg;
        UpdateHealthBar(this._HP);
        if (this._HP <= 0)
        {
            this.gameObject.SetActive(false);
            GameManager.Instant.Kill++;
        }
    }

    public void SetActive()
    {
        this.gameObject.SetActive(false);
    }

    public void UpdateHealthBar(float maxValue)
    {
        _slider.value = maxValue;
    }
}
