﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairSet : MonoBehaviour
{
    [SerializeField] int startingValue = 5;
    [SerializeField] int lowIncrease = 10;
    [SerializeField] int highIncrease = 40;
    int value = 0;

    RepairableObject repairable;
    Socket[] sockets;
    SocketComponent[] components;

    void Start()
    {
        value = startingValue;
        ObjectDeliveryControl.Singleton.SentIt.AddListener(AddValue);
    }
    void OnDestroy()
    {
        ObjectDeliveryControl.Singleton.SentIt.RemoveListener(AddValue);
    }

    public void SetReferences(RepairableObject rep, Socket[] soc, SocketComponent[] com)
    {
        repairable = rep;
        sockets = soc;
        components = com;
    }

    //Manage value and income from sending it
    public void IncreaseValueLow()
    {
        value += lowIncrease;
    }
    public void IncreaseValueHigh()
    {
        value += highIncrease;
    }
    void AddValue()
    {
        foreach(Socket s in sockets)
        {
            if (s.transform.childCount == 0)
                continue;

            //Check component has been slotted in
            SocketComponent component = transform.GetChild(0).GetComponent<SocketComponent>();
            
            if (component != null)
            {
                if (component.componentType == s.CorrectComponent)
                {
                    IncreaseValueHigh();
                }
                else
                {
                    IncreaseValueLow();
                }
            }
        }

        MoneyManager.Increase(value);
    }

}
