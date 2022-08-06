using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DataStructs;
using System;

public class Deck : MonoBehaviour
{
    [SerializeField]
    private List<CardData> StartingDeck;
    private List<Card> StartingDeckSnapshot;
    public List<Card> CurrentDeck { get; private set; }
    public Player Owner { get; set; }

    public void InitializeDeck()
    {
        if (StartingDeck.Count > 0)
        {
            CurrentDeck = new List<Card>();
            foreach (CardData cardData in StartingDeck)
            {
                Card newCard = cardData.ToCard();
                CurrentDeck.Add(newCard);
            }
            StartingDeckSnapshot = new List<Card>(CurrentDeck);
        }
    }

    public void ShuffleIntoDeck(Card card)
    {
        CurrentDeck.Add(card);
        card.CurrentOwner = Owner;
        card.CurrentZone = Zone.Deck;
        ShuffleDeck();
    }

    public void DrawNextCard()
    {
        if (CurrentDeck.Count > 0)
        {
            DrawCard(0);
        }
        else
        {
            //room for future fatigue mechanic
        }
    }

    public void DrawSpecificCard(Card card)
    {
        DrawCard(CurrentDeck.IndexOf(card));
    }

    private void DrawCard(int cardIndex)
    {
        Card drawnCard = CurrentDeck[cardIndex];
        CurrentDeck.RemoveAt(cardIndex);
        //ADD EVENT HERE
        Owner.Hand.AddCardToHand(drawnCard);
    }

    /// <summary>
    /// Returns a random card from the deck WITHOUT removing it.
    /// </summary>
    /// <param name="numOfCards"></param>
    /// <returns></returns>
    public List<Card> GetRandomCard()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Returns a random card of a certain type from the deck WITHOUT removing it.
    /// </summary>
    /// <param name="numOfCards"></param>
    /// <returns></returns>
    public List<Card> GetRandomCard(CardType cardType)
    {
        throw new System.NotImplementedException();
    }

    public bool ContainsCard(Card card)
    {
        return CurrentDeck.Contains(card);
    }

    /// <summary>
    /// TODO: Get a card answering a certain condition (type/subtype/stat above x)
    /// </summary>
    //public List<Card> GetRandomCard(ConditionLogic)
    //{

    //}

    public bool WasInStartingDeck(Card card)
    {
        return StartingDeckSnapshot.Contains(card);
    }

    public void ShuffleDeck()
    {
        CurrentDeck.Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

static class ShuffleClass
{
    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
