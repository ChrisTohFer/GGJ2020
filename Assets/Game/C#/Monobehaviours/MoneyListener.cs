using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyListener : MonoBehaviour
{
    //References
    [SerializeField] TextMeshProUGUI moneyDisplay;
    [SerializeField] string currencyIcon = "¬";

    [Tooltip("MoneyChange stuff")]
    [SerializeField] GameObject textPrefab;
    [SerializeField] Color positiveColor;
    [SerializeField] Color negativeColor;

    static MoneyListener Singleton;

    void Start()
    {
        Singleton = this;
        MoneyManager.Singleton.MoneyChanged.AddListener(OnMoneyChanged);
        UpdateCurrencyDisplay(MoneyManager.Amount);
    }
    void OnDisable()
    {
        MoneyManager.Singleton.MoneyChanged.RemoveListener(OnMoneyChanged);
    }

    void UpdateCurrencyDisplay(int amount)
    {
        moneyDisplay.text = amount.ToString() + currencyIcon;
    }

    void OnMoneyChanged(int change, int newAmount)
    {
        UpdateCurrencyDisplay(newAmount);

        //display money change
        GameObject go = Instantiate(textPrefab, transform.parent);
        go.transform.position = go.transform.position + Vector3.down * 30;
        TextMeshProUGUI textmesh = go.GetComponent<TextMeshProUGUI>();

        if(change > 0)
        {
            textmesh.color = positiveColor;
            textmesh.text =  "+" + change.ToString() + currencyIcon;
        }
        else
        {
            textmesh.color = negativeColor;
            textmesh.text = change.ToString() + currencyIcon;
        }
    }

    public static void DisplayPerfect()
    {
        GameObject go = Instantiate(Singleton.textPrefab, Singleton.transform.parent);
        go.transform.position = go.transform.position + Vector3.down * 60;
        
        TextMeshProUGUI textmesh = go.GetComponent<TextMeshProUGUI>();
        textmesh.color = Singleton.positiveColor;
        textmesh.text = "PERFECT!";


    }

}
