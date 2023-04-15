using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;

public class Relay : MonoBehaviour
{
    [SerializeField] private TMP_Text _joinCodetext;
    [SerializeField] private TMP_InputField _joinInput;
    [SerializeField] private GameObject _buttons;

    private UnityTransport _transport;
    private const int MaxPlayers = 4;

    private async void Awake()
    {
        _transport = FindObjectOfType<UnityTransport>();
    }
    

    public async void CreateGame()
    {
        _buttons.SetActive(false);

        Allocation allocation = await RelayService.Instance.CreateAllocationAsync(MaxPlayers - 1);
        _joinCodetext.text = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
        
        _transport.SetHostRelayData(allocation.RelayServer.IpV4, (ushort)allocation.RelayServer.Port, allocation.AllocationIdBytes, allocation.Key, allocation.ConnectionData);

        NetworkManager.Singleton.StartHost();
    }

    public async void JoinGame()
    {
        _buttons.SetActive(false);

        JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(_joinInput.text);
        _joinCodetext.text = await RelayService.Instance.GetJoinCodeAsync(joinAllocation.AllocationId);
        
        _transport.SetClientRelayData(joinAllocation.RelayServer.IpV4, (ushort)joinAllocation.RelayServer.Port, joinAllocation.AllocationIdBytes, joinAllocation.Key, joinAllocation.ConnectionData, joinAllocation.HostConnectionData);

        NetworkManager.Singleton.StartClient();
    }
    
}
