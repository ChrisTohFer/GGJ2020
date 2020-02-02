using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    //
    [SerializeField] float RadiansPerUnit = 1f;
    [SerializeField] Transform OptionalOtherTransform;

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
            Transform t = (OptionalOtherTransform == null) ? transform : OptionalOtherTransform;
            t.localEulerAngles = new Vector3(t.localEulerAngles.x
                                            , t.localEulerAngles.y - RadiansPerUnit * Input.GetAxis("Mouse X")
                                            , t.localEulerAngles.z);
        }
    }

    void OnMouseDown()
    {
        Rotating = true;
    }

}
