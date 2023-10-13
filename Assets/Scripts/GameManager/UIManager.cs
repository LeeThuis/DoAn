using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    public Slider _HpBar;
    
    public Button _button;
    public Button _gameOver;

    public Text _textHpBar;
    public Text _scoreText;
    public Text _yourPoint;
    public Text _highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        _button.onClick.AddListener(StartGameBt);
        _gameOver.gameObject.SetActive(false);
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
        _yourPoint.text =  string.Format("Your Point {0:00#}", GameManager.Instant.Kill.ToString());
        _gameOver.onClick.AddListener(RestartGame);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void UIScore(int score)
    {
        _scoreText.text = string.Format("total kills {0:00#}", score);
        //PlayerPrefs.SetInt("HighScore", score);
    }

    public void HighScore()
    {
        _highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
