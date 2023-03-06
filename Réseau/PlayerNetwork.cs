using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    public PlayerMovement PlayerMovement;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        PlayerMovement.enabled = IsOwner;
    }
}
