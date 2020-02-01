using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PurchaseControl : MonoBehaviour
{
    //
    public UnityEvent Purchase;
    [SerializeField] int cost;

    public void ButtonPressed()
    {
        if(MoneyManager.Decrease(cost))
        {
            Purchase.Invoke();
        }
    }
}
