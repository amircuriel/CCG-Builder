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
    [SerializeField] private List<EffectTriggerPair> effectsByTriggers;
    #endregion

    public override CardType getCardType()
    {
        return CardType.Minion;
    }

    public string getSubtypeString()
    {
        return _tribe == MinionSubtype.None ? null : _tribe.ToString();
    }

    public int BaseAttack { get => _baseAttack; set => _baseAttack = value; }
    public int BaseHealth { get => _baseHealth; set => _baseHealth = value; }
}
