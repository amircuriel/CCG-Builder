using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : CardController
{
    public Minion ControlledMinion { get => ControlledCard as Minion; private set => ControlledCard = value; }
    private GameObject MinionControllerPrefab;
    public override GameObject ControllerPrefab { get => MinionControllerPrefab; }
    // Start is called before the first frame update
    void Start()
    {
        //WORK IN PROGRESS
        foreach (TriggeredEffect eventTrigger in ControlledMinion.EventTriggers)
        {
            EventManager.Instance.Subscribe(ControlledMinion.InstanceID, eventTrigger);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
