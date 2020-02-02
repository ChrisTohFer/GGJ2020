using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twirling : MonoBehaviour
{
    [SerializeField] Vector3 initialRotation;   //0 to 2pi, incremented each frame depending on period
    [SerializeField] Vector3 rotationPeriod = new Vector3(1,1,1);
    [SerializeField] Vector3 rotationScale;

    void Update()
    {
        initialRotation.x = Mathf.Repeat(initialRotation.x + (Time.deltaTime / rotationPeriod.x) * 2f * Mathf.PI, 2f * Mathf.PI);
        initialRotation.y = Mathf.Repeat(initialRotation.y + (Time.deltaTime / rotationPeriod.y) * 2f * Mathf.PI, 2f * Mathf.PI);
        initialRotation.z = Mathf.Repeat(initialRotation.z + (Time.deltaTime / rotationPeriod.z) * 2f * Mathf.PI, 2f * Mathf.PI);
        transform.localEulerAngles = 180f / Mathf.PI * new Vector3(
                                    Mathf.Sin(initialRotation.x) * rotationScale.x,
                                    Mathf.Sin(initialRotation.y) * rotationScale.y,
                                    Mathf.Sin(initialRotation.z) * rotationScale.z);
    }
}
        