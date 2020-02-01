using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static void RandomizeArray<TYPE>(TYPE[] strings)
    {
        Random rng = new Random();

        //Copied from stack overflow boo yah
        int n = strings.Length;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            TYPE value = strings[k];
            strings[k] = strings[n];
            strings[n] = value;
        }
    }
}
