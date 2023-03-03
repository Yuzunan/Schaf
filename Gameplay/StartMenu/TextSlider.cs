using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextSlider : MonoBehaviour
{
    public TextMeshProUGUI numbertext;
    private Slider slider;

    public void Start()
    {
        slider = GetComponent<Slider>();
        SetNumberText(slider.value);
    }

    public void SetNumberText(float value)
    {
        numbertext.text = value.ToString();
    }
}

