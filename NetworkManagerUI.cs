using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    public GameObject managerUI;
    public Button serverBtn;
    public Button hostBtn;
    public Button clientBtn;

    private void Awake()
    {
        serverBtn.onClick.AddListener(() => {
            NetworkManager.Singleton.StartServer();
            managerUI.SetActive(false);
        });
        hostBtn.onClick.AddListener(() => {
            NetworkManager.Singleton.StartHost();
            managerUI.SetActive(false);
        });
        clientBtn.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
            managerUI.SetActive(false);
        });
    }
}
