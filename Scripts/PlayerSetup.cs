
using UnityEngine;
using Mirror;

[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    [SerializeField]
    private string remoteLayerName = "RemotePlayer";

    Camera sceneCamera;

    [SerializeField]
    private GameObject playerUiPrefab;
    [HideInInspector]
    public GameObject playerUiInstance;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssignRemoteLayer();
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }

            playerUiInstance = Instantiate(playerUiPrefab);
            PlayerUI ui = playerUiInstance.GetComponent<PlayerUI>();
            if (ui == null)
            {
                Debug.LogError("UI is null");
            }
            else
            {
                ui.SetPlayer(GetComponent<Player>());
            }
            GetComponent<Player>().Setup();
        }

        //CmdSetUserName(transform.name, UserAccountManager.LoggedInUsername);
    }

    [Command]
    void CmdSetUserName(string playerID, string username)
    {
        Player player = GameManager.GetPlayer(playerID);
        if (player != null)
        {
            Debug.Log(username + " has joined !");
            player.username = username;
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        RegisterPlayerAndSetUsername();
    }

    private void RegisterPlayerAndSetUsername()
    {
        string netId = GetComponent<NetworkIdentity>().netId.ToString();
        Player player = GetComponent<Player>();

        GameManager.RegisterPlayer(netId, player);
        CmdSetUserName(transform.name, UserAccountManager.LoggedInUsername);
    }

    private void AssignRemoteLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }

    private void DisableComponents()
    {
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
        }
    }

    private void OnDisable()
    {
        Destroy(playerUiInstance);

        if (isLocalPlayer)
        {
            GameManager.instance.SetSceneCameraActive(true);
        }

        GameManager.UnregisterPlayer(transform.name);
    }

}
