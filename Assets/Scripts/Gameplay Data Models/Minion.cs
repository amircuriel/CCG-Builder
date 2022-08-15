using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructs;

public class Minion : Card
{
    public MinionData BaseMinion { get => BaseCard as MinionData; }
    public List<TriggeredEffect> EventTriggers;
    public Minion(MinionData minionData) : base(minionData)
    {
        Debug.Log("Constructed Card - Minion");
        _standardVariablesByEnum.Add(CardVariable.BaseAttack, BaseMinion.BaseAttack);
        _standardVariablesByEnum.Add(CardVariable.Attack, BaseMinion.BaseCost);
        _standardVariablesByEnum.Add(CardVariable.BaseHealth, BaseMinion.BaseCost);
        _standardVariablesByEnum.Add(CardVariable.MaxHealth, BaseMinion.BaseCost);
        _standardVariablesByEnum.Add(CardVariable.Health, BaseMinion.BaseCost);
        

        
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
