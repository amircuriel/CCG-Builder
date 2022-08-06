using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructs;
using Cysharp.Threading.Tasks;

public class Player : MonoBehaviour, IDamageable
{
    public Deck Deck;
    public Hand Hand;
    public Board Board;

    public int maxHealth = 30;
    public int CurrentHealth { get; private set; }
    public bool isMyTurn { get; set; }
    public bool isFirst { get; set; }
    public bool IsCurrentlyTargetable { get; set; }
    private int turnNumber;

    public Player OpposingPlayer { get => GameSessionManager.Instance.PlayerOne == this
            ? GameSessionManager.Instance.PlayerTwo : GameSessionManager.Instance.PlayerOne; }

    // Start is called before the first frame update
    void Awake()
    {
        CurrentHealth = maxHealth;
        Deck.Owner = Hand.Owner = Board.Owner = this;
        turnNumber = 0;
    }

    public async UniTask InitializePlayer()
    {
        Deck.InitializeDeck();
        for (int i = 0; i < GameSessionManager.StartingHandSize; i++)
        { 
            Deck.DrawNextCard();
        }
        UniTask mulligan = Mulligan();
        await mulligan;
    }

    private async UniTask Mulligan()
    {
        //Placeholder for mulligan function, intended to wait for player input to confirm their mulligan/starting hand
        await UniTask.Delay(1000);
        Debug.Log("Mulligan Completed");
    }

    public void GiveControl()
    {
        isMyTurn = true;
    }

    public void PlayCard(Card card)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Me dead now.");
    }

    public TargetableType GetTargetType()
    {
        return TargetableType.Player;
    }

    public Player GetOwner()
    {
        return this;
    }

    public bool DoesOwnCard(Card card)
    {
        switch (card.CurrentZone)
        {
            case Zone.InPlay:
                return Board.ContainsCard(card);
            case Zone.Hand:
                return Hand.ContainsCard(card);
            case Zone.Deck:
                return Deck.ContainsCard(card);
            default:
                return false;
        }
    }
}
