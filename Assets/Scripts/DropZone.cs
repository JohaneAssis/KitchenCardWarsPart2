using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Dragable.Slot        typeOfItem = Dragable.Slot.ONPLAY;
    public GameObject           player;
    public GameObject           enemy;

    public GameObject           poof;

    void Start()
    {
        findObject();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }

        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        if (d != null)
        {
            if (typeOfItem == d.typeOfItem)
            {
                d.placeholderParent = this.transform;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }

        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        if (d != null && d.placeholderParent == this.transform)
        {
            if (typeOfItem == d.typeOfItem)
            {
                d.placeholderParent = d.parentToReturnTo;
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {        
        //Debug.Log(eventData.pointerDrag.name + " was dropped on to " + gameObject.name);

        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        if (d != null)
        {
            if (player.GetComponent<Player>().energy >= eventData.pointerDrag.gameObject.GetComponent<Card>().cost)
            {
                if (this.typeOfItem == Dragable.Slot.ONPLAY && d.typeOfItem == Dragable.Slot.CARD)
                {
                    if (enemy != null)
                    {
                        d.parentToReturnTo = this.transform;
                        GameObject card = eventData.pointerDrag.gameObject;
                        if (card.GetComponent<Animator>() != null)
                        {
                            Animator anim = card.GetComponent<Animator>();
                            Debug.Log(anim.name + " here");
                            anim.SetTrigger("used");

                        }
                        else
                        {
                            Debug.Log("it NOT here");
                        }
                        //CardThings(eventData.pointerDrag.gameObject);

                        GameObject[] parms = new GameObject[1] { eventData.pointerDrag.gameObject };
                        StartCoroutine("Wait", parms);
                    }
                }
            }
        }
    }

    //Coroutines
    IEnumerator Wait(GameObject[] parms)
    {
        GameObject thing = parms[0];
        yield return new WaitForSeconds(1f);
        Instantiate(poof, new Vector2(this.transform.position.x, this.transform.position.y+200), Quaternion.identity, this.transform.parent);
        CardThings(thing);
        Destroy(thing);

        yield return null;
    }

    //Functions
    public void CardThings(GameObject card)
    {
        player.GetComponent<Player>().health += card.GetComponent<Card>().health;           //playerHealth
        player.GetComponent<Player>().shield += card.GetComponent<Card>().shield;           //playerShield
        player.GetComponent<Player>().energy -= card.GetComponent<Card>().cost;             //playerEnergy
        player.GetComponent<Player>().energy += card.GetComponent<Card>().energy;           //playerEnergy

        //ATTACK
        if (enemy.GetComponent<Enemy>().shield > 0) //If enemy is shielded
        {
            //Damages shield and excess damage goes to health
            if (card.GetComponent<Card>().attack > enemy.GetComponent<Enemy>().shield)
            {
                int rollover = card.GetComponent<Card>().attack - enemy.GetComponent<Enemy>().shield;
                enemy.GetComponent<Enemy>().shield = 0;
                enemy.GetComponent<Enemy>().health -= rollover;
            }
            else
                enemy.GetComponent<Enemy>().shield -= card.GetComponent<Card>().attack;
        }
        else
            enemy.GetComponent<Enemy>().health -= card.GetComponent<Card>().attack;

        //CARD ANIMATION
        if (card.GetComponent<Animator>() != null)
        {
            Animator anim = card.GetComponent<Animator>();
            Debug.Log(anim.name +" here");
            anim.SetTrigger("used");
            
        }
        else
        {
            Debug.Log("it NOT here");
        }
    }

    public void findObject()
    {
        player = GameObject.Find("Player");
        enemy = GameObject.FindGameObjectWithTag("enemy");
    }
}
