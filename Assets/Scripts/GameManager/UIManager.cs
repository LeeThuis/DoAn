using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    public Slider _HpBar;
    public Text _textHpBar;
    public Button _button;
    public Button _gameOver;
    public Text _scoreText;


    // Start is called before the first frame update
    void Start()
    {
        _button.onClick.AddListener(StartGameBt);
        _gameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHealthBar(float value)
    {
        _HpBar.value = value;
        _textHpBar.text = value.ToString();
    }

    private void StartGameBt()
    {
        EnemyManager.Instant.Init();
        _button.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        _gameOver.gameObject.SetActive(true);
        _gameOver.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void UIScore(int score)
    {
        _scoreText.text = string.Format("total kills {0:00#}", score);
    }
}
