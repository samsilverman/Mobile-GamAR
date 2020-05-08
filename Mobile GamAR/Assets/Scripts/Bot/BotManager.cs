using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotManager : MonoBehaviour
{
    public ManipulationManager manipulationManager;

    List<GameObject> handCards = new List<GameObject>();
    int currPoint = 0;
    bool done = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Add cards to the hand
    public void AddCardToHand(GameObject card)
    {
        handCards.Add(card);
        currPoint += CardNameToPoint(card);
    }

    void FlipHandCards()
    {
        foreach (GameObject card in handCards)
        {
            card.transform.Rotate(new Vector3(0, 0, 180));
        }

    }

    int CardNameToPoint(GameObject card)
    {
        string name = card.gameObject.name;
        char firstLetter = name[0];
        if (firstLetter >= '2' && firstLetter <= '9')
        {
            return firstLetter - '0';
        }
        else if (firstLetter == '1' || firstLetter == 'J' || firstLetter == 'Q' || firstLetter == 'K')
        {
            return 10;
        }
        else if (firstLetter == 'A')
        {
            // if the current point = 10
            if (currPoint == 10)
            {
                return 11;
            }
            else return 1;
        }
        else return -100; // error return
    }
}
