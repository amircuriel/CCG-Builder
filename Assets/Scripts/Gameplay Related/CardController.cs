using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructs;

public abstract class CardController : MonoBehaviour
{
    public Card ControlledCard { get; protected set; }
    public CardDisplay LinkedDisplay;
    public abstract GameObject ControllerPrefab { get; }
    // Start is called before the first frame update
    void Start()
    {
        LinkedDisplay.InitializeCardDisplay(ControlledCard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
