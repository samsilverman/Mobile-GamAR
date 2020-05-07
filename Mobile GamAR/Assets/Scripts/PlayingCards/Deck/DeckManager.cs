using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    // prefabs of cards
    public GameObject[] cards;

    public Transform dealtCardSpawnPoint;

    // cards within the deck
    List<GameObject> deck;

    // spacing between cards in deck
    float cardDistance = 0.0005f;

    GameObject dealtCard;
    List<GameObject> collectedCards;
    GameObject discardedCard;

    private void Start()
    {
        CreateNewDeck();
        dealtCard = null;
        collectedCards = new List<GameObject>();
        discardedCard = null;
    }

    private void Update()
    {
        // move dealtCard from deck towards dealtCardSpawnPoint
        if (dealtCard != null)
        {
            dealtCard.transform.position = Vector3.MoveTowards(dealtCard.transform.position, dealtCardSpawnPoint.position, Time.deltaTime);

            // clear dealtCard if at dealtCardSpawnPoint
            if (dealtCard.transform.position == dealtCardSpawnPoint.position)
            {
                dealtCard = null;
            }
        }

        // move collectedCards towards deck 
        if (collectedCards.Count > 0)
        {
            // create copy of collectedCards to allow removal without errors
            GameObject[] collectedCardsCopy = collectedCards.ToArray();

            foreach (GameObject collectedCard in collectedCardsCopy)
            {
                collectedCard.transform.position = Vector3.MoveTowards(collectedCard.transform.position, transform.position, Time.deltaTime);
                // remove collectedCard from collectedCards if at deck
                if (collectedCard.transform.position == transform.position)
                {
                    collectedCards.Remove(collectedCard);
                }
            }

            // when all collectedCards are at deck, create a new deck
            if (collectedCards.Count == 0)
            {
                CreateNewDeck();
            }
        }

        // move discardedCard towards deck
        if (discardedCard != null)
        {
            discardedCard.transform.position = Vector3.MoveTowards(discardedCard.transform.position, transform.position, Time.deltaTime);

            // clear discardedCard if at deck
            if (discardedCard.transform.position == transform.position)
            {
                // add discardedCard into deck
                AddCardToTopOfDeck(discardedCard);
                discardedCard = null;
                Shuffle();
            }
        }
    }

    private void CreateNewDeck()
    {
        deck = new List<GameObject>();
        // copy card prefab to deck and add to top
        foreach (GameObject cardPrefab in cards)
        {
            GameObject card = Instantiate(cardPrefab, transform.position, transform.rotation, transform);
            AddCardToTopOfDeck(card);
        }
        Shuffle();
    }

    public void AddCardToTopOfDeck(GameObject card)
    {
        // remove BoxCollider of card to not allow detection when in deck
        card.GetComponent<BoxCollider>().enabled = false;

        // move card to desired position&rotation within deck
        card.transform.position = new Vector3(
            transform.position.x,
            transform.position.y + (deck.Count * cardDistance),
            transform.position.z);

        card.transform.rotation = new Quaternion(
            transform.rotation.x,
            transform.rotation.y,
            transform.rotation.z,
            transform.rotation.w
            );

        deck.Insert(0, card);
    }

    public void AddCardToBottomOfDeck(GameObject card)
    {
        // add card to front of deck
        deck.Add(card);

        // re-add all cards to top of deck so card is now at bottom
        foreach (GameObject deckCard in deck)
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

        // swap cards of array 100 times
        for (int i = 0; i < 100; i++)
        {
            int randomIndex1 = Random.Range(0, deckArray.Length);
            int randomIndex2 = Random.Range(0, deckArray.Length);

            GameObject tempCard = deckArray[randomIndex1];
            deckArray[randomIndex1] = deckArray[randomIndex2];
            deckArray[randomIndex2] = tempCard;
        }

        // add shuffled cards back into deck 
        deck = new List<GameObject>();

        foreach (GameObject card in deckArray)
        {
            AddCardToTopOfDeck(card);
        }
    }

    public void CollectAllCards()
    {
        // add all cards in scene to collectedCards
        GameObject[] activeCards = GameObject.FindGameObjectsWithTag("Card");
        foreach (GameObject card in activeCards)
        {
            card.transform.parent = transform;
            card.transform.rotation = transform.rotation;
            collectedCards.Add(card);
        }
    }

    public void DealCard()
    {
        if (deck.Count == 0)
        {
            return;
        }

        if (dealtCard != null)
        {
            return;
        }

        // remove top card from deck
        GameObject card = deck[0];
        deck.RemoveAt(0);

        // enable BoxCollider to allow detection since not in deck
        card.GetComponent<BoxCollider>().enabled = true;
        // dealtCard's parent is not longer deck
        card.transform.parent = transform.parent;

        // set dealtCard to card
        dealtCard = card;
    }

    public void DiscardCard(GameObject card)
    {
        // set discardedCard to card
        discardedCard = card;
        card.transform.parent = transform;
        card.GetComponent<BoxCollider>().enabled = false;
    }

}
