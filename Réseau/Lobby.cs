using System;
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;

namespace Schaf.Réseau
{
    public class Lobby : MonoBehaviour
    {
        private Unity.Services.Lobbies.Models.Lobby _hostLobby;
        private float heartbeatTimer;
        private string playerName;
    
        private async void Start()
        {
            await UnityServices.InitializeAsync();

            AuthenticationService.Instance.SignedIn += () =>
            {
                Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
            };
       
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            playerName = "Joueur" + UnityEngine.Random.Range(1, 5);
        }

        private void Update()
        {
            HandleLobbyHeartbeat();
        }

        private async void HandleLobbyHeartbeat()
        {
            if (_hostLobby != null)
            {
                heartbeatTimer -= Time.deltaTime;
                if (heartbeatTimer <= 0f)
                {
                    float MaxheartbeatTimer = 15;
                    heartbeatTimer = MaxheartbeatTimer;

                    await LobbyService.Instance.SendHeartbeatPingAsync(_hostLobby.Id);
                }
                
            }
            
        }

        private async void CreateLobby()
        {
            try
            {
                string LobbyName = "My Lobby";
                int maxPlayers = 4;
                CreateLobbyOptions createLobbyOptions = new CreateLobbyOptions
                {
                    IsPrivate = false,
                    Player = GetPlayer()
                };
                
                Unity.Services.Lobbies.Models.Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(LobbyName, maxPlayers);

                _hostLobby = lobby;

                Debug.Log($"Created Lobby: {lobby.Name} {lobby.MaxPlayers}");
                
                PrintPlayers(_hostLobby);
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
                throw;
            }
        
        }

        private async void ListLobbies()
        {
            try
            {
                QueryLobbiesOptions queryLobbiesOptions = new QueryLobbiesOptions
                {
                    Count = 25,
                    Filters = new List<QueryFilter>
                    {
                        new QueryFilter(QueryFilter.FieldOptions.AvailableSlots, "0", QueryFilter.OpOptions.GT)
                    },
                    Order = new List<QueryOrder>
                    {
                        new QueryOrder(false, QueryOrder.FieldOptions.Created)
                    }
                };
                
                QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync();

                Debug.Log($"Lobbies found: {queryResponse.Results.Count}");
                foreach (Unity.Services.Lobbies.Models.Lobby lobby in queryResponse.Results)
                {
                    Debug.Log($"{lobby.Name} {lobby.MaxPlayers}");
                }
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
                throw;
            }
        }
        
        private async void JoinLobby()
        {
            try
            {
                JoinLobbyByIdOptions joinLobbyByIdOptions = new JoinLobbyByIdOptions
                {
                    Player = GetPlayer()
                };
                QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync();
                await Lobbies.Instance.JoinLobbyByIdAsync(queryResponse.Results[0].Id, joinLobbyByIdOptions);
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
                throw;
            }
        }
        
        private async void JoinLobbyByCode(string lobbyCode)
        {
            try
            {
                JoinLobbyByCodeOptions joinLobbyByCodeOptions = new JoinLobbyByCodeOptions
                {
                    Player = GetPlayer()
                };
                await Lobbies.Instance.JoinLobbyByCodeAsync(lobbyCode, joinLobbyByCodeOptions);
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
                throw;
            }
        }
        
        private async void QuickJoinLobby()
        {
            try
            {
                await Lobbies.Instance.QuickJoinLobbyAsync();
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
                throw;
            }
        }

        private Player GetPlayer()
        {
            return new Player
            {
                Data = new Dictionary<string, PlayerDataObject>
                {
                    { "PlayerName", new PlayerDataObject(PlayerDataObject.VisibilityOptions.Member, playerName) }
                }
            };
        }

        private void PrintPlayers(Unity.Services.Lobbies.Models.Lobby lobby)
        {
            Debug.Log("Players in Lobby " + lobby.Name);
            foreach (Player player in lobby.Players)
            {
                Debug.Log(player.Id + " " + player.Data["PlayerName"].Value);
            }
        }

        private async void LeaveLobby()
        {
            try
            {
                await LobbyService.Instance.RemovePlayerAsync(_hostLobby.Id, AuthenticationService.Instance.PlayerId);
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
                throw;
            }
        }

    }

}
