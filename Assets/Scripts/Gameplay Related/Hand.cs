using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<Card> CurrentHand { get; private set; }
    public List<Card> StartingHandSnapshot { get; private set; }
    public Player Owner { get; set; }

    private void Awake()
    {
        CurrentHand = new List<Card>();
    }

    public void InitializeHand()
    {
        StartingHandSnapshot = new List<Card>(CurrentHand);
    }

    public void AddCardToHand(Card card)
    {
        Card c = new Minion(card.BaseCard as MinionData);
        CurrentHand.Add(card);
        card.CurrentOwner = Owner;
        card.CurrentZone = DataStructs.Zone.Hand;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal bool ContainsCard(Card card)
    {
        throw new NotImplementedException();
    }
}
