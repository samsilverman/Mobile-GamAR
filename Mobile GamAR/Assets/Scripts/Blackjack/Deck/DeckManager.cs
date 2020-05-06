using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public GameObject[] cards;

    public Transform dealtCardSpawnPoint;

    List<GameObject> deck;

    float cardDistance = 0.0005f;

    private void Start()
    {
        CreateNewDeck();
    }

    private void CreateNewDeck()
    {
        deck = new List<GameObject>();
        foreach (GameObject cardPrefab in cards)
        {
            GameObject cardPrefabCopy = Instantiate(cardPrefab);
            AddCardToTopOfDeck(cardPrefabCopy);
        }
        Shuffle();
    }

    public void AddCardToTopOfDeck(GameObject card)
    {
        GameObject newCard = Instantiate(card, transform.position, transform.rotation, transform);
        newCard.GetComponent<BoxCollider>().enabled = false;
        Destroy(card);

        newCard.transform.position = new Vector3(
            transform.position.x,
            transform.position.y + (deck.Count * cardDistance),
            transform.position.z);
        deck.Insert(0, newCard);
    }

    public void AddCardToBottomOfDeck(GameObject card)
    {
        deck.Insert(0, card);

        GameObject[] deckArray = deck.ToArray();

        deck = new List<GameObject>();

        foreach (GameObject deckCard in deckArray)
        {
            AddCardToTopOfDeck(deckCard);
        }
    }

    public void Shuffle()
    {
        if (deck.Count == 0)
        {
            return;
        }

        GameObject[] deckArray = deck.ToArray();
        // Shuffle cards
        for (int i = 0; i < 100; i++)
        {
            int randomIndex1 = Random.Range(0, deckArray.Length);
            int randomIndex2 = Random.Range(0, deckArray.Length);

            GameObject tempCard = deckArray[randomIndex1];
            deckArray[randomIndex1] = deckArray[randomIndex2];
            deckArray[randomIndex2] = tempCard;
        }

        deck = new List<GameObject>();

        foreach (GameObject card in deckArray)
        {
            AddCardToTopOfDeck(card);
        }

        //// Remove all visible cards from game
        //GameObject[] activeCards = GameObject.FindGameObjectsWithTag("Card");
        //Debug.Log(activeCards.Length);
        //foreach (GameObject card in activeCards)
        //{
        //    Destroy(card);
        //}

        //// Shuffle cards
        //for (int i = 0; i < 100; i++)
        //{
        //    int randomIndex1 = Random.Range(0, cards.Length);
        //    int randomIndex2 = Random.Range(0, cards.Length);

        //    GameObject tempCard = cards[randomIndex1];
        //    cards[randomIndex1] = cards[randomIndex2];
        //    cards[randomIndex2] = tempCard;
        //}

        //// Add shuffled cards to deck
        //deck = new List<GameObject>();
        //foreach (GameObject card in cards)
        //{
        //    deck.Add(card);
        //}

        //DisplayDeck();
    }

    public void CollectAllCards()
    {
        GameObject[] activeCards = GameObject.FindGameObjectsWithTag("Card");
        foreach (GameObject activeCard in activeCards)
        {
            Destroy(activeCard);
        }
        CreateNewDeck();
    }

    public void DealCard()
    {
        if (deck.Count == 0)
        {
            return;
        }

        GameObject card = deck[0];
        deck.RemoveAt(0);

        card.transform.position = dealtCardSpawnPoint.position;
        card.transform.parent = transform.parent;
        card.GetComponent<BoxCollider>().enabled = true;
    }
}
