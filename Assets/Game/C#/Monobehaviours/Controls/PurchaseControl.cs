using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PurchaseControl : MonoBehaviour
{
    //
    public UnityEvent Purchase;
    [SerializeField] int cost;

    //
    Button purchaseButton;

    void Awake()
    {
        purchaseButton = GetComponent<Button>();
        purchaseButton.onClick.AddListener(ButtonPressed);
    }
    void OnDestroy()
    {
        purchaseButton.onClick.RemoveListener(ButtonPressed);
    }

    public void ButtonPressed()
    {
        if(MoneyManager.Decrease(cost))
        {
            Purchase.Invoke();
            purchaseButton.interactable = false;
        }
    }
}
