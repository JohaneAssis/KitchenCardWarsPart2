using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatNShrink : MonoBehaviour
{
    public float timer = 0.0f;
    public float speed = .75f;

    public RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = this.transform.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        rect.position = new Vector3(rect.position.x, rect.position.y +(speed * Time.deltaTime), rect.position.z);
        if (timer > 2.5)
        {
            Destroy(this.gameObject);
        }

        //Destroy(this.gameObject);
    }
}
