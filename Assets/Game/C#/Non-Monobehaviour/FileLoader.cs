using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

class GameIOFunctions
{
    public static string[] ReadFile(string path, bool randomize = true)
    {
        if(!File.Exists(path))
        {
            Debug.Log("Could not find file at path: " + path);
            return new string[0];
        }

        string[] strings = File.ReadAllLines(path);
        if (randomize)
            Utils.RandomizeArray<string>(strings);

        return strings;
    }

    public static string[] ReadNounList(bool randomize = true)
    {
        return ReadFile("configs/NounList.txt", randomize);
    }

    public static string[] ReadVerbList(bool randomize = true)
    {
        return ReadFile("configs/VerbList.txt", randomize);
    }
}
