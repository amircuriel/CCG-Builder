using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DataStructs;

public class CardDisplay : MonoBehaviour 
{
    #region UI References
    [SerializeField]
	private Image ArtworkImage;
	[SerializeField]
	private TMP_Text NameText;
	[SerializeField]
	private TMP_Text DescriptionText;

	[SerializeField]
	private TMP_Text CostText;
    [Header("Situational Parameters")]
	[SerializeField]
	private TMP_Text AttackText;
	[SerializeField]
	private TMP_Text HealthText;
	[SerializeField]
	private TMP_Text SubtypeText;
	[SerializeField]
	private Image SubtypeTextBox;
    //[SerializeField]
    //private Image CardTemplate; //Not yet implemented, intended to change the card border according to its type/rarity. could also be non-serializeable, and set automatically according to the type
    #endregion

    private void Start()
    {
		InitializeBaseCardDisplay();
    }

    /// <summary>
    /// Used inside the game to display the current card values (in case a new card is intialized with already modified stats)
    /// </summary>
    /// <param name="Card"></param>
    public void InitializeCardDisplay(Card Card)
	{
		InitializeAppearance(Card._cardData);

		UpdateDisplayedValues(Card);
	}

	/// <summary>
	/// Used outside the game, for example in a card library/collection
	/// </summary>
	/// <param name="Card"></param>
    [ContextMenu("InitializeBaseCardDisplay")]
	private void InitializeBaseCardDisplay() 
	{
		CardData Card = GetComponentInParent<Card>()._cardData;
		
		InitializeAppearance(Card);

		CostText.text = Card.BaseCost.ToString();
        switch (Card.getCardType())
        {
            case CardType.Minion:
				AttackText.text = (Card as MinionData).BaseAttack.ToString();
				HealthText.text = (Card as MinionData).BaseHealth.ToString();
				break;
            case CardType.Spell:
                break;
            case CardType.Weapon:
				Debug.LogError("Not implemented!");
				//AttackText.text = (card as WeaponData).BaseAttack.ToString();
				//HealthText.text = (card as WeaponData).BaseDurability.ToString();
				break;
            default:
				Debug.LogError("Card type not implemented!");
				break;
        }
	}

	private void InitializeAppearance(CardData Card)
    {
		ArtworkImage.sprite = Card.Artwork;
		NameText.text = Card.Name;
		DescriptionText.text = Card.Description;

		string s = Card is ISubtypeable t ? t.getSubtypeString() : null;
		if (s != null)
		{
			SubtypeText.text = s;
			SubtypeTextBox.gameObject.SetActive(true);
		}
		else if (SubtypeTextBox != null)
		{
			SubtypeTextBox.gameObject.SetActive(false);
		}
	}

	public void UpdateDisplayedValues(Card card)
    {
		CostText.text = card.GetVariable(CardVariable.Cost).ToString();
		CostText.color = GetAppropriateColor(card.GetVariable(CardVariable.Cost), card.GetVariable(CardVariable.BaseCost));
		switch (card._cardData.getCardType())
		{
			case CardType.Minion:
				AttackText.text = card.GetVariable(CardVariable.Attack).ToString();
				AttackText.color = GetAppropriateColor(card.GetVariable(CardVariable.Attack), card.GetVariable(CardVariable.BaseAttack));
				HealthText.text = card.GetVariable(CardVariable.Health).ToString();
				HealthText.color = GetAppropriateColor(card.GetVariable(CardVariable.Health), card.GetVariable(CardVariable.MaxHealth));
				break;
			case CardType.Spell:
				break;
			case CardType.Weapon:
				Debug.LogError("Not implemented!");
				//AttackText.text = (card as WeaponData).BaseAttack.ToString();
				//HealthText.text = (card as WeaponData).BaseDurability.ToString();
				break;
			default:
				Debug.LogError("Card type not implemented!");
				break;
		}
    }

	public Color GetAppropriateColor(int currentValue, int maximumValue)
    {
        if (currentValue < maximumValue)
        {
			return Color.red;
        }
        else if (currentValue > maximumValue)
        {
			return Color.green;
        }
        else
        {
			return Color.white;
        }
    }
}
