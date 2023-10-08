using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void UpdateHealthBar(float maxValue)
    {
        _slider.value = maxValue;
    }
}
