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

    void Start()
    {
        MoneyManager.Singleton.MoneyChanged.AddListener(OnMoneyChanged);
    }
    void OnDisable()
    {
        MoneyManager.Singleton.MoneyChanged.RemoveListener(OnMoneyChanged);
    }

    void OnMoneyChanged(int change, int newAmount)
    {
        //update currency display
        moneyDisplay.text = newAmount.ToString() + currencyIcon;

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

}
