using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private BaseController _baseController;
    public BaseController BaseController => _baseController;

    [SerializeField] private EnemyManager _enemyManager;
    public EnemyManager _nemyManager => _enemyManager;

    private int _kill = 0;

    public int Kill
    {
        get
        {
            return _kill;
        }
        set
        {
            if (value <= 0)
                value = 0;
            _kill = value;

            UIManager.Instant.UIScore(_kill);
            CheckHighScore();
        }
    }


    private void CheckHighScore()
    {
        if (_kill > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", _kill);
        }
    }
}
