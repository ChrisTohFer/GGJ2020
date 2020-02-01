using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeOutText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textmesh;
    [SerializeField] float duration;
    [SerializeField] Vector3 velocity;

    void Update()
    {
        float alpha = textmesh.color.a;
        alpha -= Time.deltaTime / duration;

        if(alpha <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            Color c = textmesh.color;
            textmesh.color = new Color(c.r, c.g, c.b, alpha);

            transform.position += velocity * Time.deltaTime;
        }
    }
}
