using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStackManager : MonoBehaviour
{
    float cardDistance = 0.0005f;

    Stack<GameObject> cards;

    // Called on objects that are instantiated
    void Awake()
    {
        cards = new Stack<GameObject>();
    }

    public void AddCardToStack(GameObject card)
    {
        card.transform.position = new Vector3(
            transform.position.x,
            transform.position.y + (cards.Count * cardDistance),
            transform.position.z);
        cards.Push(card);
    }

    public void RemoveCardFromStack()
    {
        GameObject card = cards.Pop();
        Destroy(card);
        if (cards.Count == 0)
        {
            DeleteCardStack();
        }
    }

    public void ShuffleStack()
    {
        GameObject[] cardsArray = cards.ToArray();

        // Shuffle cards
        for (int i = 0; i < 100; i++)
        {
            int randomIndex1 = Random.Range(0, cardsArray.Length);
            int randomIndex2 = Random.Range(0, cardsArray.Length);

            GameObject tempCard = cardsArray[randomIndex1];
            cardsArray[randomIndex1] = cardsArray[randomIndex2];
            cardsArray[randomIndex2] = tempCard;
        }

        cards = new Stack<GameObject>();

        foreach (GameObject card in cardsArray)
        {
            cards.Push(card);
        }
    }

    public void DeleteCardStack()
    {
        GameObject deck = GameObject.FindGameObjectWithTag("Deck");

        foreach (GameObject card in cards)
        {
            Destroy(card);
        }
        Destroy(gameObject);
    }

    public int GetCardStackSize()
    {
        return cards.Count;
    }
}
