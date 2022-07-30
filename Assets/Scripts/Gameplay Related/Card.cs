using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructs;

public abstract class Card : MonoBehaviour
{
    public int InstanceID { get; protected set; }
    public CardData _cardData { get; protected set; }
    protected List<Modifier> _modifiers;
    protected Dictionary<CardVariable, int> _standardVariablesByEnum;
    protected Dictionary<string, int> _uniqueVariablesByName;
    protected Zone _currentZone;

    private void Awake()
    {
        InitializeBaseCard(_cardData);
    }

    protected void InitializeBaseCard(CardData cardData)
    {
        Debug.Log("Called InitializeBaseCard");

        _standardVariablesByEnum = new Dictionary<CardVariable, int>();
        _uniqueVariablesByName = new Dictionary<string, int>();
        _modifiers = new List<Modifier>();
        _standardVariablesByEnum.Add(CardVariable.BaseCost, cardData.BaseCost);
        _standardVariablesByEnum.Add(CardVariable.Cost, cardData.BaseCost);
        //EXPAND
        InitializeCardVariant(cardData);
    }

    protected abstract void InitializeCardVariant(CardData cardData);

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
                Debug.LogError("ERROR: Unique variable not found: " + uniqueVariableName);
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
                Debug.LogError("ERROR: Card does not contain variable - " + variable.ToString());
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
                Debug.LogError("ERROR: Unique variable not found: " + model.UniqueVariableName);
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
                Debug.LogError("ERROR: Card does not contain variable: " + model.VariableToChange.ToString());
            }
        }
    }
}
