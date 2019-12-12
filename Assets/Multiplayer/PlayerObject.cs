using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer == false)
        {
            //this object belongs to another player
            return;
        }

        Debug.Log("playerObject::Start -- Spawning my own personal unit.");

        //Instatiate() only creates an object on the local computer
        //even if it has a network identity
        //must call NetworkServer.Spawn()
        //Instantiate(PlayerUnitPrefab);
        CmdSpawnMyUint();
    }

    public GameObject PlayerUnitPrefab;
    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer == false)
        {
            return;
        }

        /*if (Input.GetKeyDown(KeyCode.W))
        {
            CmdMoveUnit();
        }*/
    }

    GameObject myPlayerUnit;

    [Command]
    void CmdSpawnMyUint()
    {
        GameObject go = Instantiate(PlayerUnitPrefab);

        myPlayerUnit = go;

        //go.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);

        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
    }

    [Command]
    void CmdMoveUnit()
    {
        if (myPlayerUnit == null)
        {
            return;
        }

        myPlayerUnit.transform.Translate(Vector2.up * .5f);
    }
}
