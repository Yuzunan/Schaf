using System;
using UnityEngine;
using Unity.Netcode;

namespace Schaf.Réseau
{
    public class NetworkManagerUI : MonoBehaviour
    {
        public void StartClient()
        {
            NetworkManager.Singleton.StartClient();
        }

        public void StartHost()
        {
            NetworkManager.Singleton.StartHost();
        }

        public void StartServer()
        {
            NetworkManager.Singleton.StartServer();
        }
    }
}
