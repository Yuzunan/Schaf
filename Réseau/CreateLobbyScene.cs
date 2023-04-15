using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CreateLobbyScene : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInput, _maxPlayersInput;

    private void Start() 
    {
        
        void SetOptions(TMP_Dropdown dropdown, IEnumerable<string> values) 
        {
            dropdown.options = values.Select(type => new TMP_Dropdown.OptionData { text = type }).ToList();
        }
    }

    public static event Action<LobbyData> LobbyCreated;

    public void OnCreateClicked() 
    {
        var lobbyData = new LobbyData 
        {
            Name = _nameInput.text,
            MaxPlayers = int.Parse(_maxPlayersInput.text),
        };

        LobbyCreated?.Invoke(lobbyData);
    }
}

public struct LobbyData 
{
    public string Name;
    public int MaxPlayers;
}
