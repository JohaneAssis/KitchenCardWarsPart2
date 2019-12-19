using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    private static bool created = false;

    public bool         attackCard;
    public bool         energyCard;
    public bool         healthCard;
    public bool         shieldCard;
    public bool         vampireCard;

    public GameObject CardActiveButton;
    public GameObject CardActiveCanvas;
    public GameObject backButton;
    GameObject copy;

    public Text[] texts;
    //[0] Attack text
    //[1] Energy text
    //[2] Health text
    //[3] Shield text
    //[4] Vampirism text

    public void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);

            /*
            copy = GameObject.Find("Card Manager").gameObject;
            if (copy != null)
            {
                Destroy(copy);
            }
            this.gameObject.name = "Card Manager";
            */
        }
    }

    public void Start()
    {
        attackCard = true;
        energyCard = true;
        healthCard = true;
        shieldCard = true;
        vampireCard = true;

        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = "True";
        }
    }

    //===================================
    //              Fucntions
    //===================================

    public void openMenu()
    {
        if (CardActiveCanvas.active == false)
        {
            CardActiveCanvas.SetActive(true);
        }
    }

    public void closeMenu()
    {
        if (CardActiveCanvas.active == true)
        {
            CardActiveCanvas.SetActive(false);
        }
    }

    public void restoreAll()
    {
        attackCard = true;
        energyCard = true;
        healthCard = true;
        shieldCard = true;
        vampireCard = true;

        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = "True";
        }
    }

    //===================================
    //         Setting the Cards
    //===================================

    public void A_Set()
    {
        //from on to OFF
        if (attackCard == true)
        {
            attackCard = false;
            texts[0].text = "False";
        }

        //from off to ON
        else if (attackCard == false)
        {
            attackCard = true;
            texts[0].text = "True";
        }

        Debug.Log("Attack_Setting");
    }

    public void E_Set()
    {
        //from on to OFF
        if (energyCard == true)
        {
            energyCard = false;
            texts[1].text = "False";
        }

        //from off to ON
        else if (energyCard == false)
        {
            energyCard = true;
            texts[1].text = "True";
        }

        Debug.Log("Energy_Setting");
    }

    public void H_Set()
    {
        //from on to OFF
        if (healthCard == true)
        {
            healthCard = false;
            texts[2].text = "False";
        }

        //from off to ON
        else if (healthCard == false)
        {
            healthCard = true;
            texts[2].text = "True";
        }

        Debug.Log("Health_Setting");
    }

    public void S_Set()
    {
        //from on to OFF
        if (shieldCard == true)
        {
            shieldCard = false;
            texts[3].text = "False";
        }

        //from off to ON
        else if (shieldCard == false)
        {
            shieldCard = true;
            texts[3].text = "True";
        }

        Debug.Log("Shield_Setting");
    }

    public void V_Set()
    {
        //from on to OFF
        if (vampireCard == true)
        {
            vampireCard = false;
            texts[4].text = "False";
        }

        //from off to ON
        else if (vampireCard == false)
        {
            vampireCard = true;
            texts[4].text = "True";
        }

        Debug.Log("Attack_Setting");
    }
}
