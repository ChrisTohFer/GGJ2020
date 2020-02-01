using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairableObject : MonoBehaviour
{
    //
    [SerializeField] Transform[] socketLocations;

    public void AddRandomSockets(Socket[] sockets)
    {
        //Adds sockets to random slots, written while tired so may be buggy
        for(int i = 0; i < sockets.Length && i < socketLocations.Length; ++i)
        {
            int index = Random.Range(0, socketLocations.Length - i);
            while (socketLocations[index].childCount > 0)
                ++index;
            Transform t = sockets[i].transform;
            t.SetParent(socketLocations[index]);
            t.localPosition = Vector3.zero;
            t.eulerAngles = Vector3.zero;
        }
    }

}
