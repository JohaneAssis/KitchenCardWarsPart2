using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNGone : MonoBehaviour
{
    float           timer           = 0.0f;
    public float    collapseTime    = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > collapseTime)
        {
            Destroy(this.gameObject);
        }
    }
}
