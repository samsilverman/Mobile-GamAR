//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DeckManager : MonoBehaviour
//{
//    public GameObject[] cards;

//    public Transform dealtCardSpawnPoint;

//    List<GameObject> deck;

//    private void Start()
//    {
//        Shuffle();
//    }

//    public void Shuffle()
//    {
//        // Remove all visible cards from game
//        GameObject[] activeCards = GameObject.FindGameObjectsWithTag("Card");
//        Debug.Log(activeCards.Length);
//        foreach (GameObject card in activeCards)
//        {
//            Destroy(card);
//        }

//        // Shuffle cards
//        for (int i = 0; i < 100; i++)
//        {
//            int randomIndex1 = Random.Range(0, cards.Length);
//            int randomIndex2 = Random.Range(0, cards.Length);

//            GameObject tempCard = cards[randomIndex1];
//            cards[randomIndex1] = cards[randomIndex2];
//            cards[randomIndex2] = tempCard;
//        }

//        // Add shuffled cards to deck
//        deck = new List<GameObject>();
//        foreach (GameObject card in cards)
//        {
//            deck.Add(card);
//        }

//        DisplayDeck();
//    }

//    void DisplayDeck()
//    {
//        float positionOffset = 0.0005f;

//        // Stack deck's cards on each other
//        for (int i = 0; i < deck.Count; i++)
//        {
//            deck[i] = Instantiate(deck[i], transform.position, transform.rotation, transform);
//            deck[i].transform.position = new Vector3(deck[i].transform.position.x, deck[i].transform.position.y + (positionOffset * i), deck[i].transform.position.z);
//            // Remove box collider of deck cards (dont want to select a non-dealt card)
//            deck[i].GetComponent<BoxCollider>().enabled = false;
//        }
//    }

//    public void DealCard()
//    {
//        if (deck.Count == 0)
//        {
//            return;
//        }

//        // remove top card
//        GameObject card = deck[deck.Count - 1];
//        deck.Remove(card);

//        card.transform.position = dealtCardSpawnPoint.position;
//        card.transform.parent = transform.parent;
//        card.GetComponent<BoxCollider>().enabled = true;
//    }

//    public void Discard(GameObject card)
//    {
//        if (deck.Count == 0)
//        {
//            deck.Add(card);
//        }
//        else
//        {
//            deck.Insert(deck.Count - 1, card);
//        }
//        DisplayDeck();
//        Destroy(card);
//    }
//}
