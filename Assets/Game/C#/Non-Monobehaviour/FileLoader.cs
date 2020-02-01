using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

class GAME_IO_FUNCTIONS
{
    public static string[] ReadFile(string path)
    {
        Debug.Log(Directory.GetCurrentDirectory());

        if(!File.Exists(path))
        {
            Debug.Log("Could not find file at path: " + path);
            return null;
        }

        return File.ReadAllLines(path);
    }

    public static string[] ReadNounList()
    {
        return ReadFile("configs/NounList.txt");
    }

    public static string[] ReadVerbList()
    {
        return ReadFile("configs/VerbList.txt");
    }
}
