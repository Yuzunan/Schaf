using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthentificationManager : MonoBehaviour
{
    [SerializeField] private string LobbyScene;

    public async void LoginAnonymously() 
    {
        await Authentication.Login();
        SceneManager.LoadSceneAsync(LobbyScene);
    }
    
}
