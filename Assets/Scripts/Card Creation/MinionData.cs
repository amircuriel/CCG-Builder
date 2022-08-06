using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructs;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Minion", menuName = "New Card/Minion", order = 1)]
public class MinionData : CardData, ISubtypeable
{
    #region Serialized Properties
    [SerializeField] private int _baseAttack;
    [SerializeField] private int _baseHealth;
    [SerializeField] private MinionSubtype _tribe = MinionSubtype.None;
    [SerializeField] private List<EventTrigger> eventTriggers;
    #endregion

    public override Card ToCard()
    {
        return new Minion(this);
    }

    public override CardType getCardType()
    {
        return CardType.Minion;
    }

    public string GetSubtypeString()
    {
        return _tribe == MinionSubtype.None ? null : _tribe.ToString();
    }

    public int BaseAttack { get => _baseAttack; set => _baseAttack = value; }
    public int BaseHealth { get => _baseHealth; set => _baseHealth = value; }
    public List<EventTrigger> EffectsByTriggers { get => new List<EventTrigger>(eventTriggers);}
}
