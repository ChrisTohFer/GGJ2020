using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyboardListener : MonoBehaviour
{
    public UnityEvent hpressed;
    public UnityEvent mpressed;
    public GameObject HelpUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            hpressed.Invoke();
            HelpUI.SetActive(!HelpUI.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            mpressed.Invoke();
            AudioManager.PlayMoneyIncome();
        }
    }
}
