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
    [SerializeField] int id;

    bool purchased = false;
    bool bookOpen = false;

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
        if(!purchased)
        {
            if (MoneyManager.Decrease(cost))
            {
                Purchase.Invoke();
                purchased = true;
            }
        }
        else
        {
            if(bookOpen)
            {
                TextBoxController.ReturnMainText();
                bookOpen = false;
            }
            else
            {
                string componentString = LanguageManager.Singleton.components.GetAlienByIndex(id) + " = " + LanguageManager.Singleton.components.GetTypeByIndex(id) + " component";
                string socketString = LanguageManager.Singleton.sockets.GetAlienByIndex(id) + " = " + LanguageManager.Singleton.sockets.GetTypeByIndex(id) + " socket";

                TextBoxController.ChangeText(componentString + "\n" + socketString, false);
                bookOpen = true;
            }
        }
    }
}
