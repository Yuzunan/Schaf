using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeforeGameUI : MonoBehaviour
{
    [SerializeField] private Button Ready;

    private void Awake()
    {
        Ready.onClick.AddListener(() =>
        {
            BeforeGameReady.Instance.SetPlayerReady();
        });
    }
}
