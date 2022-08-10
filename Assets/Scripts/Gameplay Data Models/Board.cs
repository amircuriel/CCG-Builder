using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<Card> CardsInPlay { get; private set; }
    public Player Owner { get; set; }

    void Awake()
    {
        CardsInPlay = new List<Card>();
    }

    public void PutCardInPlay(Card card)
    {
        CardsInPlay.Add(card);
        card.CurrentOwner = Owner;
        card.CurrentZone = DataStructs.Zone.InPlay;
    }

    public bool ContainsCard(Card card)
    {
        return CardsInPlay.Contains(card);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
