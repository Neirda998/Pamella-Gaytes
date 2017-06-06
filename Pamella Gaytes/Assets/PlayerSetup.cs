using UnityEngine;
using UnityEngine.Networking;


public class PlayerSetup : NetworkBehaviour {
    [SerializeField]
    Behaviour[] componentsToDisable;

    public GameObject player;
    public Transform pos;

    Camera sceneCamera = Camera.main;
    //NetworkMessageInfo info = new NetworkMessageInfo();
    void Start()
    {
        if(!isLocalPlayer)
        {
            for(int i = 0 ; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
                Transform posi =GetComponent<Transform>();
            }
        }
        else
        {
            //OnNetworkInstantiate(info);
        }
    }

    public override void OnStartLocalPlayer()
    {
       pos = GetComponent<Transform>();
    }
    private void OnNetworkInstantiate(NetworkMessageInfo info)
    {
        NetworkView nView = GetComponent<NetworkView>();
        if (nView.isMine)
        {

            sceneCamera.GetComponent<SecurityCamera>().target = pos;

        }    

    }
}
