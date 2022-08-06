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
    /// <summary>
    /// All possible types of events that can occur in the game, usually as a result of player actions.
    /// </summary>
    public enum GameEvent
    {
        OnPlay,
        OnSummon,
        AfterSummon,
        OnSpellcast,
        AfterSpellcast,
        OnDeath,
        OnDraw,
        OnDiscard,
        OnAttack,
        AfterAttack,
        OnAttacked,
        AfterAttacked,
        OnDamage,
        OnHeal,
        EndOfTurn,
        StartOfTurn
    }
    
    public enum TriggerType
    {
        ActiveCardAction,
        GameEvent
    }

    public enum GameEventListener
    {
        OnPlayerValueChanged,
        OnOpponentValueChanged
    }

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

    public enum GlobalVariable
    {

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
        None = 0,
        InPlay = 1,
        Hand = 2,
        Deck = 3,
        //Graveyard = 4,
        //RemovedFromGame = 5,
        //SetAside = 6,
        //Discarded = 7
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

    #region Interfaces (temp location)
    public interface ITargetable
    {
        public bool IsCurrentlyTargetable { get; }
        public TargetableType GetTargetType();
        public Player GetOwner();
    }

    public interface IDamageable : ITargetable
    {
        public int CurrentHealth { get; }
        public void ApplyDamage(int damage);
    }

    public interface IBoardPresent
    {
        int BoardPosition { get; }
    }

    public interface ISubtypeable
    {
        public string GetSubtypeString();
    }
    #endregion
}
