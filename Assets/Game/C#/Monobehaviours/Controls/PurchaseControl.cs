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
    [SerializeField] GameObject SendItButton;

    bool purchased = false;
    bool bookOpen = false;

    UnityEvent openbook = new UnityEvent();

    //
    Button purchaseButton;

    void Awake()
    {
        openbook.AddListener(SetOpenFalse);
        purchaseButton = GetComponent<Button>();
        purchaseButton.onClick.AddListener(ButtonPressed);
    }
    void OnDestroy()
    {
        openbook.RemoveListener(SetOpenFalse);
        purchaseButton.onClick.RemoveListener(ButtonPressed);
    }

    void SetOpenFalse()
    {
        bookOpen = false;
    }

    public void ButtonPressed()
    {
        if(!purchased)
        {
            if (MoneyManager.Decrease(cost))
            {
                Purchase.Invoke();
                purchased = true;
                OpenBook();
            }
        }
        else
        {
            if(bookOpen)
            {
                CloseBook();
            }
            else
            {
                OpenBook();
            }
        }
    }

    void OpenBook()
    {
        openbook.Invoke();
        string componentString = LanguageManager.Singleton.components.GetAlienByIndex(id) + " = " + LanguageManager.Singleton.components.GetTypeByIndex(id) + " component";
        string socketString = LanguageManager.Singleton.sockets.GetAlienByIndex(id) + " = " + LanguageManager.Singleton.sockets.GetTypeByIndex(id) + " socket";

        TextBoxController.ChangeText(componentString + "\n" + socketString, false);
        bookOpen = true;
        SendItButton.SetActive(false);
    }
    void CloseBook()
    {
        TextBoxController.ReturnMainText();
        bookOpen = false;
        SendItButton.SetActive(true);
    }
}
