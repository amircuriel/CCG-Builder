using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructs;

public class Spell : Card
{
    public SpellData BaseSpell { get => BaseCard as SpellData; }
    public Spell(SpellData spellData) : base(spellData)
    {

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
