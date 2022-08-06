using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructs;

/// <summary>
/// Contains all the current values and data for a unique instance of a card.
/// Used only during gameplay as a data 'model', alongside "CardController" and "CardDisplay".
/// Children include "Minion" and "Spell".
/// </summary>
public abstract class Card
{
    public int InstanceID { get; private set; }
    public CardData BaseCard { get; protected set; }
    public Zone CurrentZone { get; set; }
    public Player CurrentOwner { get; set; }

    protected Dictionary<CardVariable, int> _standardVariablesByEnum;
    protected Dictionary<string, int> _uniqueVariablesByName;
    protected List<Modifier> _modifiers;

    protected Card(CardData cardData)
    {
        BaseCard = cardData;
        _standardVariablesByEnum = new Dictionary<CardVariable, int>();
        _uniqueVariablesByName = new Dictionary<string, int>();
        _modifiers = new List<Modifier>();
        _standardVariablesByEnum.Add(CardVariable.BaseCost, cardData.BaseCost);
        _standardVariablesByEnum.Add(CardVariable.Cost, cardData.BaseCost);
        InstanceID = GameSessionManager.GenerateUniqueID();
    }

    public abstract void OnPlay();
    public abstract void OnDraw();
    public abstract void OnDiscard();
    public abstract void OnValueChanged();
    public abstract void OnModifiersChanged();
    public abstract void ClearAllModifiers();

    public virtual int GetVariable(CardVariable variable, string uniqueVariableName = "N/A")
    {
        if (variable == CardVariable.UniqueNamedVariable)
        {
            if (_uniqueVariablesByName.ContainsKey(uniqueVariableName))
            {
                return _uniqueVariablesByName[uniqueVariableName];
            }
            else
            {
                //IMPROVE//
                Debug.LogError("ERROR: Unique variable not found on " + BaseCard.Name + ": " + uniqueVariableName);
                return int.MinValue;
            }
        }
        else
        {
            if (_standardVariablesByEnum.ContainsKey(variable))
            {
                return _standardVariablesByEnum[variable];
            }
            else
            {
                //IMPROVE//
                Debug.LogError("ERROR: " + BaseCard.Name + " does not contain variable - " + variable.ToString());
                return int.MinValue;
            }
        }
    }

    public virtual void SetVariable(SetVariableModel model)
    {
        if (model.VariableToChange == CardVariable.UniqueNamedVariable)
        {
            if (_uniqueVariablesByName.ContainsKey(model.UniqueVariableName))
            {
                _uniqueVariablesByName[model.UniqueVariableName] = model.IsIncremental
                    ? _uniqueVariablesByName[model.UniqueVariableName] + model.Value : model.Value;
            }
            else
            {
                //Initializes the variable
                _uniqueVariablesByName.Add(model.UniqueVariableName, model.Value);
            }
        }
        else
        {
            if (_standardVariablesByEnum.ContainsKey(model.VariableToChange))
            {
                _standardVariablesByEnum[model.VariableToChange] = model.IsIncremental
                    ? _standardVariablesByEnum[model.VariableToChange] + model.Value : model.Value;
            }
            else
            {
                //IMPROVE//
                Debug.LogError("ERROR: " + BaseCard.Name + " does not contain variable: " + model.VariableToChange.ToString());
            }
        }
    }
}
