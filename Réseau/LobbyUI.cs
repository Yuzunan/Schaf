using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    [SerializeField] private Button CreateLobby;
    [SerializeField] private Button JoinLobby;
    [SerializeField] private String gameStartScene;

    private void Awake()
    {
        CreateLobby.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            NetworkManager.Singleton.SceneManager.LoadScene(gameStartScene, LoadSceneMode.Single);
        });
        
        JoinLobby.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }
}
