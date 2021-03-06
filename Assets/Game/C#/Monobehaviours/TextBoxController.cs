﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBoxController : MonoBehaviour
{
    public static TextBoxController Singleton;

    //References
    [SerializeField] TextMeshProUGUI textbox;
    [SerializeField] Animator animator;
    [SerializeField] string newtext;
    [SerializeField] bool applynewtext;

    string MainText = "";

    void Awake()
    {
        Singleton = this;
    }

    //Move textbox offscreen
    public static void HideTextBox()
    {
        Singleton.animator.SetBool("Shown", false);
    }
    //Move textbox onscreen
    public static void ShowTextBox()
    {
        Singleton.animator.SetBool("Shown", true);
    }
    //Move textbox offscreen and bring back with new text
    public static void ChangeText(string message, bool maintext = true)
    {
        var stateinfo = Singleton.animator.GetCurrentAnimatorStateInfo(0);

        if (maintext)
            Singleton.MainText = message;

        if (stateinfo.IsName("OffScreen"))
        {
            ShowNewText(message);
        }
        else
        {
            HideTextBox();
            Singleton.StopAllCoroutines();
            Singleton.StartCoroutine(Singleton.WaitForTextToLeaveScreen(message));
        }
    }

    //Returns main text to box, in case of alternate text being shown
    public static void ReturnMainText()
    {
        ChangeText(Singleton.MainText);
    }

    //Change text and bring textbox back onto screen
    public static void ShowNewText(string message)
    {
        Singleton.textbox.text = message;
        ShowTextBox();
    }

    //Waits for text to leave the screen and then shows a new message
    IEnumerator WaitForTextToLeaveScreen(string message)
    {
        var stateinfo = Singleton.animator.GetCurrentAnimatorStateInfo(0);
        while (!stateinfo.IsName("OffScreen"))
        {
            yield return new WaitForEndOfFrame();
            stateinfo = Singleton.animator.GetCurrentAnimatorStateInfo(0);
        }

        ShowNewText(message);
    }

    void Update()
    {
        if(applynewtext)
        {
            applynewtext = false;
            ChangeText(newtext);
        }
    }
}
