using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

/// <summary>
/// sdasdasd
/// </summary>
namespace DataStructs
{
    public interface ISubtypeable
    {
        string getSubtypeString();
    }

    public enum TriggerType
    {
        ActiveCardAction,
        GameEvent
    }

    /// <summary>
    /// All possible types of occurences that would trigger an effect.
    /// </summary>
    public enum Trigger
    {
        OnPlay,
        OnDeath,
        OnDraw,
        OnDiscard,
        BeforeAttack,
        AfterAttack,
        OnDamaged,
        OnHealed,
        OnValueChanged
    }

    public enum GameEventListener
    {
        OnPlayerValueChanged,
        OnOpponentValueChanged
    }

    [Serializable]
    /// <summary>
    /// Card variables that can be checked or changed (only numerically)
    /// </summary>
    public enum CardVariable
    {
        Cost,
        BaseCost,
        Attack,
        BaseAttack,
        Health,
        MaxHealth,
        BaseHealth,
        Durability,
        BaseDurability,
        UniqueNamedVariable
    }

    [Serializable]
    public struct SetVariableModel
    {
        public CardVariable VariableToChange;
        public bool IsIncremental;
        public int Value;
        [DrawIf("variable", CardVariable.UniqueNamedVariable)]
        public string UniqueVariableName;

        public SetVariableModel(CardVariable cardVariable, bool isIncremental, int value, string uniqueVariableName = "N/A")
        {
            VariableToChange = cardVariable;
            IsIncremental = isIncremental;
            Value = value;
            UniqueVariableName = uniqueVariableName;
        }
    }

    public enum Ownership
    {
        Friendly,
        Enemy,
        Both
    }
    
    public enum Timeframe
    {
        ThisTurn,
        LastTurn,
        ThisGame
    }

    public enum MinionSubtype
    {
        None,
        Beast,
        Demon,
        Mech,
        Elemental,
        Dragon,
        All
    }

    public enum SpellSubtype
    {
        None,
        Fire,
        Frost,
        Arcane,
        Nature,
        Shadow,
        Holy
    }
    
    public enum CardType
    {
        Minion,
        Spell,
        Weapon
    }

    /// <summary>
    /// Non-Mutually-Exclusive tags for marking cards with various properties for future use
    /// (For example, if I want to mark a card as part of a certain group of cards without using subtypes)
    /// </summary>
    public enum CardTag
    {
        
    }

    public enum Zone
    {
        InPlay = 1,
        Hand = 2,
        Deck = 3,
        Graveyard = 4,
        RemovedFromGame = 5,
        SetAside = 6,
        Discarded = 7
    }

    public enum AffectedTargets
    {
        Targeted,
        Self,
        All,
        Random
    }

    public enum TargetableType
    {
        Minion,
        Player,
        Character, //Minion + Player
        Weapon
    }

    public interface ITargetable
    {
        bool isTargetable { get; }
        TargetableType getTargetType();
    }

    public interface IDamageable : ITargetable
    {
        int currentHealth { get; }
        void ApplyDamage(int damage);
    }

    public interface IBoardPresent
    {
        int BoardPosition { get; }
    }
}
