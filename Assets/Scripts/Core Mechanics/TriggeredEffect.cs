using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructs;

/// <summary>
/// Cards with EventTriggers will listen to GameEvents coming from specific origins (including themselves),
/// and play their effects when such events occur.
/// This includes both one-time effects (when this is played / when this dies), 
/// and constant listeners (whenever [event] happens while this is in play)
/// </summary>
[System.Serializable]
public struct EventTrigger
{
    public GameEvent Event;
    public EventOrigin EventOrigin;
    public TriggeredEffect TriggeredEffect;
    public int originatorId { get; set; }
}

/// <summary>
/// The effect will only trigger from events coming from these origins/sources.
/// </summary>
/// 1. This: Events called from this card (when you play THIS/when THIS dies/when THIS attacks)
/// 2. Other: Events called from other cards (when you play ANOTHER card/when ANOTHER minion dies/when ANOTHER minions attacks)
/// 3. Any: Events called from both this and other cards (when A minion dies/when A minion attacks/when A card is played)
/// 4. OtherFriendly/AnyFriendly/AnyEnemy: Like Other/Any, but only for friendly/enemy events (can be used to differentiate between "At the end of your turn" and "and the end of each turn").
/// 
/// NOTE: OnPlay/OnDeath/OnSummon effects, when used with the "Any/AnyFriendly" origin, will not trigger when the associated minion
/// itself is played/dies, effectively functioning as the "Other" origin.
public enum EventOrigin
{
    This,
    Other,
    OtherFriendly,
    Any,
    AnyFriendly,
    AnyEnemy
}

/// <summary>
/// Note: When creating a new triggered effect, choose the conditions and the targets, and then define the effect itself as a choice between:
/// 1. Changing the health value
/// 2. Adding a modifier
/// 3. Other
/// 
/// IF you add a modifier, then you need to also create the unique modifier, assign it a name and an ID, store it somewhere,
/// and link the effect to the modifier ID.
/// </summary>
[System.Serializable]
public struct TriggeredEffect
{
    public bool isConditional;
    [DrawIf("isConditional", true)]
    public EffectCondition triggerCondition;
    public TargetingOptions targetingOptions;
    public Effect effect;
}

/// <summary>
/// The actual effect portion that directly changes the game state.
/// </summary>
[System.Serializable]
public struct Effect
{
    /// <summary>
    /// Determines the function of the effect.
    /// </summary>
    public EffectType effectType;
    [DrawIf("effectType", EffectType.SetVariable)]
    public SetVariableModel variableParameters;
    public int numericalValue;
    public int minionOrModifierID;
    public int timesRepeated;

    public enum EffectType
    {
        DealDamage,
        RestoreHealth,
        AddModifier,
        SetVariable,
        DrawCards,
        SummonMinion
    }
}

/// <summary>
/// Determines under which conditions should the effect be allowed to occur.
/// </summary>
[System.Serializable]
public struct EffectCondition
{
    //WORK IN PROGRESS
    public bool desiredResultBoolean;
    [DrawIf("isConditional", true)]
    public ConditionCheckType conditionCheckType;
    [DrawIf("conditionCheckType", ConditionCheckType.CheckTargetForCondition)]
    public TargetConditionCheck targetConditionCheck;
    [DrawIf("isConditional", true)]
    public Condition condition;

    [System.Serializable]
    public struct TargetConditionCheck
    {
        public TargetCheckTypes targetCheckTypes;
    }

    [System.Serializable]
    public struct EventOccuredConditionCheck
    {
        public GameEvent gameEvent;
        public TargetCheckTypes targetCheckTypes;
    }

    public enum ConditionTarget
    {
        ThisCard,
        EffectTarget,
        AnyMinion,
        AnyFriendlyMinion,
        AnyEnemyMinion,
        GlobalVariable,
        CardHistory
    }

    [System.Serializable]
    public struct Condition
    {
        public ConditionCheckType conditionChecked;
        public CardType cardTypeChecked;
        public Ownership ownership;
        public Timeframe timeframe;
    }

    public enum ConditionCheckType
    {
        CheckTargetForCondition,
        CheckIfEventHasOccured
    }

    public enum TargetCheckTypes
    {
        IsOfMinionSubtype,
        IsValueEqualTo,
        IsValueMoreThan,
        IsValueLessThan
    }
}

/// <summary>
/// Determines which targets are affected by the associated effect.
/// </summary>
[System.Serializable]
public struct TargetingOptions
{
    public AffectedTargets affectedTargets;
    public Ownership relevantTargetOwnership;
    public TargetableType affectedTargetTypes;
    //TODO: Exclude this from the targeted option
    public Zone zone;
    //TODO: Targeting Condition (such as "can only target minions with less than 3 attack" or "deal damage to all non-murloc minions")
}

public struct Modifier
{
    int id;
    string name;
    int duration;
}