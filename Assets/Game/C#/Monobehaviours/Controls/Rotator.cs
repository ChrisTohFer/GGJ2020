using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    //
    [SerializeField] float RadiansPerUnit = 1f;

    //
    bool Rotating = false;

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Rotating = false;
        }
        if(Rotating)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x
                                            , transform.eulerAngles.y - RadiansPerUnit * Input.GetAxis("Mouse X")
                                            , transform.eulerAngles.z);
        }
    }

    void OnMouseDown()
    {
        Rotating = true;
    }

}
