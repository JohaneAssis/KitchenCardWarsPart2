using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public GameObject   enemy;
    GameObject          player;
    GameObject          eventSystem;
    public GameObject   winText;
    public GameObject   loseText;

    Transform           hand;

    public GameObject[] Cards = new GameObject[10];

    bool                turnSwitch;
    bool                turnSwitch2;
    bool                drawCards;

    int          maxHandSize = 7;

    enum gameState
    {
        ENEMYTURN, PLAYERTURN
    } gameState GameState;

    void Start()
    {
        GameState = gameState.PLAYERTURN;
        turnSwitch = false;
        drawCards = false;

        winText.SetActive(false);
        loseText.SetActive(false);

        findObjects();    
    }

 //=======================================
 //             Game Happenings
 //=======================================
    void Update()
    {
        if (enemy == null)
        {
            winText.SetActive(true);
            StartCoroutine("BackToMap");
        }

        switch (GameState)
        {
            case gameState.PLAYERTURN:
                turnSwitch = false;
                while (turnSwitch2 == false)                //Debug for checking turns
                {
                    Debug.Log("Player Turn");
                    turnSwitch2 = true;
                }

                while (drawCards == false)
                {
                    newHand();
                    drawCards = true;
                }

                eventSystem.gameObject.SetActive(true);
                break;

            case gameState.ENEMYTURN:
                eventSystem.gameObject.SetActive(false);
                turnSwitch2 = false;
                drawCards = false;

                while (turnSwitch == false)
                {
                    Debug.Log("Enemy Turn");
                    StartCoroutine("enemyAction");
                    turnSwitch = true;
                }
                break;
        }
    }

//========================================
//              Functions
//========================================

    void findObjects()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy");
        player = GameObject.Find("Player");
        eventSystem = GameObject.Find("EventSystem");
        hand = GameObject.Find("Hand").transform;
    }

    public void endTurn()
    {
        emptyHand();
        GameState = gameState.ENEMYTURN;
    }

    public void emptyHand()
    {
        int kidCount = hand.childCount;
       // Debug.Log(kidCount);

        for (int i = 0; i < kidCount; i++)
        {
            Destroy(hand.GetChild(i).gameObject);
            kidCount = hand.childCount;
        }
    }

    public void newHand()
    {
        int drawSize = maxHandSize;

        for (int i = 1; i <= drawSize; i++)
        {
            Instantiate(Cards[Random.RandomRange(0, Cards.Length-1)], hand);
        }
    }

    //========================================
    //              Coroutines
    //========================================

    IEnumerator BackToMap()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("WorldMap");
    }

    IEnumerator enemyAction()
    {
        yield return new WaitForSeconds(1.5f);
        int choice = Random.Range(1, 3);
        if (choice == 1)                    //Attack the player
        {
            int dealtDamage = Random.Range(5, 10);
            if (player.GetComponent<Player>().shield > 0)
            {
                if (dealtDamage > player.GetComponent<Player>().shield)
                {
                    int rollover = dealtDamage - player.GetComponent<Player>().shield;
                    player.GetComponent<Player>().shield = 0;
                    player.GetComponent<Player>().health -= rollover;
                }
                else

                    player.GetComponent<Player>().shield -= dealtDamage;
            }
            else
                player.GetComponent<Player>().health -= dealtDamage;
        }

        if (choice == 2)                    //Gives itself shield
        {
            enemy.GetComponent<Enemy>().shield += Random.Range(1, 5);
        }

        if (choice == 3)                    //Does nothing
        {

        }

        yield return new WaitForSeconds(1.5f);
        player.GetComponent<Player>().energy = player.GetComponent<Player>().energyMax;
        GameState = gameState.PLAYERTURN;

        yield return null;
    }
}
