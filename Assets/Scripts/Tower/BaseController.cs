using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour , IGetHit
{
    public float _Hp = 1000;
    private bool _flashActive;
    [SerializeField]
    private float _flashLength = 0;
    private float _flashCounter = 0;
    private SpriteRenderer _baseRenderer;

    [SerializeField] Rigidbody2D _rigiBase;

    private void Awake()
    {
        _rigiBase = this.GetComponent<Rigidbody2D>();
        _baseRenderer = this.GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if(_flashActive)
        {
            if(_flashCounter > _flashLength * 0.99f)
            {
                _baseRenderer.color = new Color(_baseRenderer.color.r, _baseRenderer.color.g, _baseRenderer.color.b, 0f);
            }
            else if( _flashCounter > _flashLength * 0.82f)
            {
                _baseRenderer.color = new Color(_baseRenderer.color.r, _baseRenderer.color.g, _baseRenderer.color.b, 1f);
            }
            else if(_flashCounter > _flashLength * 0.66f)
            {
                _baseRenderer.color = new Color(_baseRenderer.color.r, _baseRenderer.color.g, _baseRenderer.color.b, 0f);
            }
            else if (_flashCounter > _flashLength * 0.49f)
            {
                _baseRenderer.color = new Color(_baseRenderer.color.r, _baseRenderer.color.g, _baseRenderer.color.b, 1f);
            }
            else if (_flashCounter > _flashLength * 0.33f)
            {
                _baseRenderer.color = new Color(_baseRenderer.color.r, _baseRenderer.color.g, _baseRenderer.color.b, 0f);
            }
            else if (_flashCounter > _flashLength * 0.16f)
            {
                _baseRenderer.color = new Color(_baseRenderer.color.r, _baseRenderer.color.g, _baseRenderer.color.b, 1f);
            }
            else if (_flashCounter > 0f)
            {
                _baseRenderer.color = new Color(_baseRenderer.color.r, _baseRenderer.color.g, _baseRenderer.color.b, 0f);
            }
            else
            {
                _baseRenderer.color = new Color(_baseRenderer.color.r, _baseRenderer.color.g, _baseRenderer.color.b, 1f);
                _flashActive = false;
            }
            _flashCounter -= Time.deltaTime;
        }
    }

    public void GetHit(float dmg)
    {
        this._Hp -= dmg;
        _flashActive = true;
        _flashCounter = _flashLength;

        UIManager.Instant.setHealthBar(this._Hp);

        if (this._Hp <= 0)
        {
            Observer.Instant.AddListener("EndGame", null);
            UIManager.Instant.GameOver();
        }
    }
}
