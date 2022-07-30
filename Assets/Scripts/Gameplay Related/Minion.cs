using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructs;

public class Minion : Card
{
    public MinionData _minionData { get; private set; }
    public Minion(MinionData minionData)
    {
        _minionData = minionData;
        _cardData = _minionData;
    }
    
    protected override void InitializeCardVariant(CardData cardData)
    {
        Debug.Log("Called InitializeCardVariant - Minion");
        Minion a;
        a = new Minion(_minionData);
        a.GetVariable(CardVariable.Cost);

        _standardVariablesByEnum.Add(CardVariable.BaseAttack, _minionData.BaseAttack);
        _standardVariablesByEnum.Add(CardVariable.Attack, _minionData.BaseCost);
        _standardVariablesByEnum.Add(CardVariable.BaseHealth, _minionData.BaseCost);
        _standardVariablesByEnum.Add(CardVariable.MaxHealth, _minionData.BaseCost);
        _standardVariablesByEnum.Add(CardVariable.Health, _minionData.BaseCost);
        //EXPAND
    }

    public override void OnDiscard()
    {
        throw new System.NotImplementedException();
    }

    public override void OnDraw()
    {
        throw new System.NotImplementedException();
    }

    public override void OnModifiersChanged()
    {
        throw new System.NotImplementedException();
    }

    public override void OnPlay()
    {
        throw new System.NotImplementedException();
    }

    public override void OnValueChanged()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ClearAllModifiers()
    {
        throw new System.NotImplementedException();
    }
}
