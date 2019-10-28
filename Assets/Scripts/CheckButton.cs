using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckButton : MonoBehaviour
{
    public Text child;
    public int num;
    void Start()
    {
        
    }

    void Awake()
    {
        CheckB();
    }

    //visualize change
    public void CheckB()
    {
        num = int.Parse(child.text);
        if (num == 1)
        {
            child.GetComponentInParent<Text>().color = Color.white;
        }
        else
        {
            child.GetComponentInParent<Text>().color = Color.grey;
        }
    }

    //toggle on or off card
    public void changeValue()
    {
        if(child.text == "1")
        {
            child.text = "0";
        }
        else
        {
            child.text = "1";
        }
    }
}
