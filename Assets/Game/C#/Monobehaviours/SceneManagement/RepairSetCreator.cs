using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairSetCreator : MonoBehaviour
{
    public static RepairSetCreator Singleton;

    //
    [SerializeField] Transform repairSetHolder;
    [SerializeField] GameObject repairSetPrefab;
    [SerializeField] GameObject[] repairablePrefabs;
    [SerializeField] GameObject[] componentPrefabs;
    [SerializeField] GameObject[] socketPrefabs;
    [SerializeField] int[] componentsPerLevel;
    [SerializeField] int[] socketsPerLevel;
    [SerializeField] float componentRadius = 100f;

    public static RepairSet CreateRepairSet()
    {
        return Singleton.CreateRepairSetLocal();
    }
    public RepairSet CreateRepairSetLocal()
    {
        int difficulty = DifficultyManager.Singleton.Difficulty;

        //Instantiate repairset
        GameObject rsObject = Instantiate(repairSetPrefab);
        RepairSet repairSet = rsObject.GetComponent<RepairSet>();

        //Instantiate repairable object
        GameObject repairable = Instantiate(repairablePrefabs[Random.Range(0, repairablePrefabs.Length)], rsObject.transform);
        RepairableObject repairableObject = repairable.GetComponent<RepairableObject>();

        //Instantiate components
        int nComponents = componentsPerLevel[difficulty];
        SocketComponent[] components = new SocketComponent[nComponents];
        Utils.RandomizeArray<GameObject>(componentPrefabs);
        for(int i = 0; i < nComponents; ++i)
        {
            GameObject g = Instantiate(componentPrefabs[i], rsObject.transform);
            components[i] = g.GetComponent<SocketComponent>();

            //Place components in a circle around the repairable
            g.transform.localPosition = Quaternion.Euler(0f, 2f * Mathf.PI * i / nComponents, 0f) * (Vector3.left * componentRadius);
        }

        //Instantiate sockets
        int nSockets = socketsPerLevel[difficulty];
        Socket[] sockets = new Socket[nSockets];
        Utils.RandomizeArray<GameObject>(socketPrefabs);
        for (int i = 0; i < nSockets; ++i)
        {
            GameObject g = Instantiate(socketPrefabs[i]);
            sockets[i] = g.GetComponent<Socket>();
            sockets[i].CorrectComponent = components[i].componentType;
        }

        //Attach sockets
        repairableObject.AddRandomSockets(sockets);

        //Set references
        repairSet.SetReferences(repairableObject, sockets, components);

        return repairSet;
    }


}
