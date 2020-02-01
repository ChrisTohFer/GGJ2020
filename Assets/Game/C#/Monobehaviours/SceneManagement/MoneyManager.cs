using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntIntEvent : UnityEvent<int, int>
{
}

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Singleton;

    //
    [SerializeField] int StartingMoney;
    int currentMoney;

    //
    public IntIntEvent MoneyChanged;

    //
    int Amount
    {
        get { return currentMoney; }
    }

    void Awake()
    {
        Singleton = this;
        currentMoney = StartingMoney;
        MoneyChanged = new IntIntEvent();
    }

    //Increase money and return new amount
    public static int Increase(int amount)
    {
        Singleton.currentMoney += amount;
        Singleton.MoneyChanged.Invoke(amount, Singleton.currentMoney);
        return Singleton.currentMoney;
    }

    //Decrease money and return new amount
    public static int Decrease(int amount)
    {
        Singleton.currentMoney -= amount;
        Singleton.MoneyChanged.Invoke(-amount, Singleton.currentMoney);
        return Singleton.currentMoney;
    }
}
