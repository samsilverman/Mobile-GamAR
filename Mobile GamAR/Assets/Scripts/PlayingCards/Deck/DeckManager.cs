using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    // prefabs of cards
    public GameObject[] cards;

    public Transform dealtCardSpawnPoint;

    // cards within the deck
    private List<GameObject> deck;

    // spacing between cards in deck
    private float cardDistance = 0.0005f;

    // card to be dealt
    private GameObject dealtCard;

    // cards to be collected
    private List<GameObject> collectedCards;

    // card to be discarded
    private GameObject discardedCard;

    private void Start()
    {
        // initalizations
        dealtCard = null;
        collectedCards = new List<GameObject>();
        discardedCard = null;

        // create new deck on start
        CreateNewDeck();
    }

    private void Update()
    {
        // if there is a card to deal
        if (dealtCard != null)
        {
            // move card to deal towards dealtCardSpawnPoint (animation)
            dealtCard.transform.position = Vector3.MoveTowards(dealtCard.transform.position, dealtCardSpawnPoint.position, Time.deltaTime);

            // if card to deal is at dealtCardSpawnPoint, remove card to deal from dealtCard (done animation)
            if (dealtCard.transform.position == dealtCardSpawnPoint.position)
            {
                dealtCard = null;
            }
        }

        // if there are cards to collect
        if (collectedCards.Count > 0)
        {
            // create copy of collectedCards to allow removal in loop without errors
            GameObject[] collectedCardsCopy = collectedCards.ToArray();

            // move each collected card towards deck (animation)
            foreach (GameObject collectedCard in collectedCardsCopy)
            {
                collectedCard.transform.position = Vector3.MoveTowards(collectedCard.transform.position, transform.position, Time.deltaTime);
                // if collected card is at deck, remove from collectedCards (done animation)
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

        // if there is a card to discard
        if (discardedCard != null)
        {
            // move card towards deck (animation)
            discardedCard.transform.position = Vector3.MoveTowards(discardedCard.transform.position, transform.position, Time.deltaTime);

            // if card is at deck, remove from discardedCard (done animation)
            if (discardedCard.transform.position == transform.position)
            {
                // add card to deck and shuffle
                AddCardToTopOfDeck(discardedCard);
                discardedCard = null;
                Shuffle();
            }
        }
    }

    private void CreateNewDeck()
    {
        deck = new List<GameObject>();
        // copy card prefab to deck and shuffle
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
        // don't deal from empty deck
        if (deck.Count == 0)
        {
            return;
        }

        // don't deal if currently dealing a card
        if (dealtCard != null)
        {
            return;
        }

        // remove top card from deck
        GameObject card = deck[0];
        deck.RemoveAt(0);

        // enable BoxCollider to allow detection since not in deck
        card.GetComponent<BoxCollider>().enabled = true;

        // dealtCard's parent is not longer deck (allows for independent manipulation)
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
