using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructs;

/// <summary>
/// Abstract parent to all other card types, it contains all the base data of a card
/// </summary>
public abstract class CardData : ScriptableObject
{
    #region Serialized Properties
    [Header("Tags (Optional)")]
    [SerializeField] private List<CardTag> _cardTags;
    [Header("Cosmetic Properties")]
    [SerializeField] protected string _name;
    [SerializeField] protected string _description;
    [SerializeField] protected Sprite _artwork;
    [Header("Gameplay Properties")]
    [SerializeField] protected int _baseCost;
    #endregion

    public abstract CardType getCardType();

    #region Getters & Setters
    public int BaseCost { get => _baseCost; private set => _baseCost = value; }
    public string Name { get => _name; private set => _name = value; }
    public string Description { get => _description; private set => _description = value; }
    public Sprite Artwork { get => _artwork; private set => _artwork = value; }
    public List<CardTag> CardTags { get => _cardTags; private set => _cardTags = value; }
    #endregion
}