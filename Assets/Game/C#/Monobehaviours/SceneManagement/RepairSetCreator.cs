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
    [SerializeField] float componentRadius = 2f;

    void Awake()
    {
        Singleton = this;
    }

    public static RepairSet CreateRepairSet()
    {
        return Singleton.CreateRepairSetLocal();
    }
    public RepairSet CreateRepairSetLocal()
    {
        int difficulty = DifficultyManager.Singleton.Difficulty;

        //Instantiate repairset
        GameObject rsObject = Instantiate(repairSetPrefab, repairSetHolder);
        RepairSet repairSet = rsObject.GetComponent<RepairSet>();

        //Instantiate repairable object
        GameObject repairable = Instantiate(repairablePrefabs[Random.Range(0, repairablePrefabs.Length)], rsObject.transform);
        RepairableObject repairableObject = repairable.GetComponent<RepairableObject>();

        //Instantiate components
        int nComponents = componentsPerLevel[difficulty];
        SocketComponent[] components = new SocketComponent[nComponents];
        GameObject[] prefabSelection = Utils.RandomSelection<GameObject>(componentPrefabs, nComponents);
        for(int i = 0; i < nComponents; ++i)
        {
            GameObject g = Instantiate(prefabSelection[i], rsObject.transform);
            components[i] = g.GetComponent<SocketComponent>();

            //Place components in a circle around the repairable
            g.transform.localPosition = Quaternion.Euler(0f, 360 * i / nComponents, 0f) * (Vector3.left * componentRadius) + Vector3.up * .3f;
        }

        //Instantiate sockets
        int nSockets = socketsPerLevel[difficulty];
        Socket[] sockets = new Socket[nSockets];
        prefabSelection = Utils.RandomSelection<GameObject>(socketPrefabs, nSockets);

        string instructions = "";

        for (int i = 0; i < nSockets; ++i)
        {
            GameObject g = Instantiate(prefabSelection[i]);
            sockets[i] = g.GetComponent<Socket>();
            sockets[i].CorrectComponent = components[i].componentType;

            string ComponentString = LanguageManager.Singleton.components.TranslateToAlien(components[i].componentType);
            string SocketString = LanguageManager.Singleton.sockets.TranslateToAlien(sockets[i].SocketType);
            instructions += ComponentString + " -> " + SocketString + "\n";
        }

        TextBoxController.ChangeText(instructions);

        //Attach sockets
        repairableObject.AddRandomSockets(sockets);

        //Set references
        repairSet.SetReferences(repairableObject, sockets, components);

        return repairSet;
    }


}
