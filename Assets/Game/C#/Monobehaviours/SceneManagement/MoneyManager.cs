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
    public static int Amount
    {
        get { return Singleton.currentMoney; }
    }

    void Awake()
    {
        Singleton = this;
        currentMoney = StartingMoney;
        MoneyChanged = new IntIntEvent();
    }

    //Increase money and return new amount
    public static void Increase(int amount)
    {
        Singleton.currentMoney += amount;
        Singleton.MoneyChanged.Invoke(amount, Singleton.currentMoney);
    }

    public void IncreaseLocal(int amount)
    {
        Increase(amount);
    }

    //Decrease money and return new amount, returns false if money is not available
    public static bool Decrease(int amount)
    {
        if (amount <= Singleton.currentMoney)
        {
            Singleton.currentMoney -= amount;
            Singleton.MoneyChanged.Invoke(-amount, Singleton.currentMoney);
            return true;
        }
        return false;
    }
}
