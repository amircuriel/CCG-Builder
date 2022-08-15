using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructs;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Spell", menuName = "New Card/Spell", order = 2)]
public class SpellData : CardData, ISubtypeable
{
    #region Serialized Properties
    [SerializeField] private SpellSubtype _spellSchool = SpellSubtype.None;
    [SerializeField] private List<EffectCompartment> spellEffects;

    #endregion

    public override Card ToCard()
    {
        return new Spell(this);
    }

    public override CardType getCardType()
    {
        return CardType.Spell;
    }

    public string GetSubtypeString()
    {
        return _spellSchool == SpellSubtype.None ? null : _spellSchool.ToString();
    }
    public List<EffectCompartment> SpellEffects { get => new List<EffectCompartment>(spellEffects);}
}
