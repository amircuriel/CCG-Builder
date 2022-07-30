using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructs;

[System.Serializable]
public class EffectTriggerPair
{
    public Trigger Listener;
    public EffectCompartment EffectCompartment; //MAKE THIS A LIST IN THE FUTURE
    //public int pairID { get; /* set => GenerateIDFromUniqueIDGenerator; */}
}


/// <summary>
/// Note: When creating a new effect compartment, choose the conditions and the targets, and then define the effect itself as a choice between:
/// 1. Changing the health value
/// 2. Adding a modifier
/// 3. Other
/// 
/// IF you add a modifier, then you need to also create the unique modifier, assign it a name and an ID, store it somewhere,
/// and link the effect to the modifier ID.
/// </summary>
[System.Serializable]
public struct EffectCompartment
{
    public ConditionLogic condition;
    public TargetingData targetData;
    public Effect effect;
}

[System.Serializable]
public struct Effect
{
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

[System.Serializable]
public struct ConditionLogic
{
    public bool isConditional;
    [DrawIf("isConditional", true)]
    /// <summary>
    /// If true, the effect will only trigger if the condition is met. If false, the effect will only trigger if the condition is not met. 
    /// </summary>
    public bool desiredResultBoolean;
    [DrawIf("isConditional", true)]
    public Condition condition;
    [DrawIf("isConditional", true)]
    public ConditionTarget conditionTarget;

    [System.Serializable]
    public struct Condition
    {
        public ConditionChecked conditionChecked;
        public CardType cardTypeChecked;
        public Ownership ownership;
    }

    public enum ConditionChecked
    {
        WasPlayed,
        HasDied,
        DoesExist,
        ContainsKeyword,
        ContainsMinionTribe,
        ValueEqualTo
    }

    public enum ConditionTarget
    {
        EffectOrigin,
        GlobalParameter,
        EffectTarget
    }
}

[System.Serializable]
public struct TargetingData
{
    public AffectedTargets affectedTargets;
    public Ownership relevantTargetOwnership;
    public TargetableType affectedTargetTypes;
    //TODO: Exclude this from the targeted option
    public Zone zone;
    //TODO: Target Condition (such as "can only target minions with less than 3 attack" or "deal damage to all non-murloc minions")
}

public struct Modifier
{
    int id;
    string name;
    int duration;
}