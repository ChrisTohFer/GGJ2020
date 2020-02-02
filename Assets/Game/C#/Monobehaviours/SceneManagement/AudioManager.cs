using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Singleton;

    [SerializeField] AudioSource moneyIncome;
    [SerializeField] AudioSource sendItDidNothing;
    [SerializeField] AudioSource sendItYouTried;
    [SerializeField] AudioSource sendItPerfect;
    [SerializeField] AudioSource pickup;
    [SerializeField] AudioSource attach;


    void Awake()
    {
        Singleton = this;
    }

    public static void PlayMoneyIncome()
    {
        Singleton.moneyIncome.Play();
    }
    public static void PlaySendDidNothing()
    {
        Singleton.sendItDidNothing.Play();
    }
    public static void PlaySendYouTried()
    {
        Singleton.sendItYouTried.Play();
    }
    public static void PlaySendPerfect()
    {
        Singleton.sendItPerfect.Play();
    }
    public static void PlayPickup()
    {
        Singleton.pickup.Play();
    }
    public static void PlayAttach()
    {
        Singleton.attach.Play();
    }
}
