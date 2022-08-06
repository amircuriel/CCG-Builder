using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DataStructs;

public class GameSessionManager : Singleton<GameSessionManager>
{
    #region Game Rules
    [Header("Rules")]
    public static int StartingHandSize = 3;
    public static int CardsDrawnPerTurn = 1;
    #endregion

    public Player PlayerOne, PlayerTwo;
    public Player CurrentPlayer;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public async void StartGame()
    {
        bool StartingPlayer = Random.value > 0.5f;
        PlayerOne.isFirst = PlayerOne.isMyTurn = StartingPlayer;
        PlayerTwo.isFirst = PlayerTwo.isMyTurn = !StartingPlayer;

        await UniTask.WhenAll(PlayerOne.InitializePlayer(), PlayerTwo.InitializePlayer());

        CurrentPlayer.GiveControl();
    }

    public void InvokeCardEvent(GameEvent gameEvent, Card card)
    {
        //WORK IN PROGRESS
        EventManager.Instance.Broadcast(new EventManager.EventMessage(gameEvent, card));

        //await all subsequent events to resolve themselves
    }

    public void ApplyEffect(TriggeredEffect effect)
    {
        //WORK IN PROGRESS
    }

    #region Unique ID Generator
    private static int nextID = 0;
    public static int GenerateUniqueID()
    {
        return ++nextID;
    }
    #endregion
}
