using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static void RandomizeArray<TYPE>(TYPE[] arr)
    {
        Random rng = new Random();

        //Copied from stack overflow boo yah
        int n = arr.Length;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            TYPE value = arr[k];
            arr[k] = arr[n];
            arr[n] = value;
        }
    }

    public static TYPE[] RandomSelection<TYPE>(TYPE[] arr, int num)
    {
        TYPE[] output = new TYPE[Mathf.Min(num, arr.Length)];
        HashSet<int> taken = new HashSet<int>();

        for (int i = 0; i < output.Length; ++i)
        {
            int index = Random.Range(0, arr.Length - i);
            while (taken.Contains(index))
                ++index;
            output[i] = arr[index];
            taken.Add(index);
        }

        return output;
    }
}
