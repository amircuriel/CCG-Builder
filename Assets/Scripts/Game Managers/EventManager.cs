using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructs;
using UnityEngine.Events;

/// <summary>
/// Manages the connection between the occuring GameEvents and the 
/// </summary>
public class EventManager : Singleton<EventManager>
{
    /// <summary>
    /// Contains all the data regarding a specific game event.
    /// </summary>
    public struct EventMessage
    {
        public GameEvent gameEvent; // never null
        public Card card;
        //public Card[] affectedCards;
        //public Card originatingCard;
        //public Zone zone;
        //public int damage;
        
        public EventMessage(GameEvent gameEvent, Card card)
        {
            this.gameEvent = gameEvent;
            this.card = card;
        }
    }

    public UnityAction<EventMessage> AnyEvent;
    public Dictionary<int, List<UnityAction<EventMessage>>> SubscribedEventsByOriginatorId;

    public void Subscribe(int originatorId, TriggeredEffect eventTrigger)
    {
        // Add this listening event to the list of listening events
        UnityAction<EventMessage> func = (EventMessage eventMessage) =>
        {
            // When an event with `eventMessage` data is broadcasted, call OnEvent with that data and the `eventTrigger` data
            OnEvent(eventTrigger, eventMessage);
        };
        AnyEvent += func;
        if (!SubscribedEventsByOriginatorId.ContainsKey(originatorId))
        {
            SubscribedEventsByOriginatorId.Add(originatorId, new List<UnityAction<EventMessage>>());
        }
        SubscribedEventsByOriginatorId[originatorId].Add(func);
    }

    /// <summary>
    /// Removes all event listeners from a card (usually used after it was removed from play or silenced)
    /// </summary>
    /// <param name="originatorId"></param>
    public void Unsubscribe(int originatorId)
    {
        foreach (UnityAction<EventMessage> response in SubscribedEventsByOriginatorId[originatorId])
        {
            AnyEvent -= response;
        }
        SubscribedEventsByOriginatorId.Remove(originatorId);
    }

    public void Broadcast(EventMessage eventMessage)
    {
        AnyEvent.Invoke(eventMessage);
    }

    private bool OnEvent(TriggeredEffect listeningTrigger, EventMessage eventMessage)
    {
        // check that event filters fit this event
        if (listeningTrigger.Trigger != eventMessage.gameEvent) 
            return false;
        if (listeningTrigger.TriggerOrigin == EventOrigin.This && eventMessage.card.InstanceID != listeningTrigger.originatorId) 
            return false;
        // apply this event's effect
        // TODO - triggered effects with logic that depends on event message
        GameSessionManager.Instance.ApplyEffect(listeningTrigger.Effect);
        return false;
        // return true if, for example, card was countered
    }
}
