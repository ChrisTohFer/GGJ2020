using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketComponent : MonoBehaviour
{
    public string componentType;

    bool pickedup = false;
    Vector3 originalPosition;
    Collider collider;
    //TODO - Add code to pick up and parent to socket

    void Awake()
    {
        collider = GetComponent<Collider>();
    }

    void Update()
    {
        if (!pickedup)
            return;

        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.tag == "Socket")
                {
                    transform.SetParent(hit.transform);
                    transform.localPosition = Vector3.zero;
                    pickedup = false;
                    AudioManager.PlayAttach();
                }
                else
                {
                    transform.localPosition = originalPosition;
                    collider.enabled = true;
                    pickedup = false;
                }
            }
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                transform.position = hit.point - ray.direction;
            }
        }
    }

    void OnMouseDown()
    {
        originalPosition = transform.localPosition;
        collider.enabled = false;
        pickedup = true;
        AudioManager.PlayPickup();
    }
}
