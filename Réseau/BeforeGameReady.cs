using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeforeGameReady : NetworkBehaviour
{
    public static BeforeGameReady Instance { get; private set; }
    private Dictionary<ulong, bool> playerReadyDictionary;
    [SerializeField] private String gameStartScene;

    private void Awake()
    {
        Instance = this;
        playerReadyDictionary = new Dictionary<ulong, bool>();
    }

    public void SetPlayerReady()
    {
        SetPlayerReadyServerRpc();
    }

    [ServerRpc(RequireOwnership = false)]
    private void SetPlayerReadyServerRpc(ServerRpcParams serverRpcParams = default)
    {
        playerReadyDictionary[serverRpcParams.Receive.SenderClientId] = true;

        bool allClientsReady = true;
        foreach (ulong client in NetworkManager.Singleton.ConnectedClientsIds)
        {
            if(!playerReadyDictionary.ContainsKey(client) || !playerReadyDictionary[client])
            {
                allClientsReady = false;
                break;
            }
        }

        if (allClientsReady)
        {
            NetworkManager.Singleton.SceneManager.LoadScene(gameStartScene, LoadSceneMode.Single);
        }
    }
}
