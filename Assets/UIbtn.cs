using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIbtn : MonoBehaviour
{
    [SerializeField] Button starBtn;

    private void Start()
    {
        starBtn.onClick.AddListener(StartBnt);
    }

    private void StartBnt()
    {
        SceneManager.LoadScene(1);
    }
}
