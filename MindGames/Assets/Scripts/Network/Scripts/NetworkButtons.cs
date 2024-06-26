using Unity.Netcode;
using UnityEngine;

namespace Network.Scripts
{
    public class NetworkButtons : MonoBehaviour
    {
        private const string Client = "Client";
        private const string Host = "Host";

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(10,10,300,300));

            if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
            {
                if (GUILayout.Button(Host))
                {
                    NetworkManager.Singleton.StartHost();
                }
                if (GUILayout.Button(Client))
                {
                    NetworkManager.Singleton.StartClient();
                }
            }
            
            GUILayout.EndArea();
        }
    }
}