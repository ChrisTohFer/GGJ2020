using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairableObject : MonoBehaviour
{
    //
    [SerializeField] Transform[] socketLocations;
    [SerializeField] int startingValue = 5;
    int value = 0;

    void Start()
    {
        value = startingValue;
        ObjectDeliveryControl.Singleton.SentIt.AddListener(AddValue);
    }
    void OnDestroy()
    {
        ObjectDeliveryControl.Singleton.SentIt.RemoveListener(AddValue);
    }

    public void AddRandomSockets(Transform[] sockets)
    {
        //Adds sockets to random slots, written while tired so may be buggy
        for(int i = 0; i < sockets.Length && i < socketLocations.Length; ++i)
        {
            int index = Random.Range(0, socketLocations.Length - i);
            while (socketLocations[index].childCount > 0)
                ++index;
            sockets[i].SetParent(socketLocations[index]);
            sockets[i].localPosition = Vector3.zero;
            sockets[i].eulerAngles = Vector3.zero;
        }
    }

    public void IncreaseValue(int amount)
    {
        value += amount;
    }

    void AddValue()
    {
        MoneyManager.Increase(value);
    }

}
