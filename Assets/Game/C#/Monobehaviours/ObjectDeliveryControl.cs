using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDeliveryControl : MonoBehaviour
{
    public static ObjectDeliveryControl Singleton;

    //
    [SerializeField] Animator animator;
    GameObject currentSet;

    //
    public UnityEvent SentIt;
    public UnityEvent ReceivedIt;

    void Awake()
    {
        Singleton = this;
    }

    public void SendAway()
    {
        animator.SetBool("SendIt", true);
        SentIt.Invoke();
        StartCoroutine(Sending());
    }

    IEnumerator Sending()
    {
        //Wait for object to be fully sent before destroying
        while(!animator.GetCurrentAnimatorStateInfo(0).IsTag("Sent"))
        {
            yield return new WaitForEndOfFrame();
        }
        Destroy(currentSet);

        StartCoroutine(Receiving());
    }

    IEnumerator Receiving()
    {
        currentSet = RepairSetCreator.CreateRepairSet().gameObject;

        animator.SetBool("SendIt", false);

        //Wait for object to fully arrive before sending event
        while (!animator.GetCurrentAnimatorStateInfo(0).IsTag("Wait"))
        {
            yield return new WaitForEndOfFrame();
        }
        ReceivedIt.Invoke();
    }

}
