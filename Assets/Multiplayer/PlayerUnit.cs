using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerUnit : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasAuthority == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            this.transform.Translate(Vector2.up * .5f);
        }
    }
}
