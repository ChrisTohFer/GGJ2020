using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int>
{
}

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Singleton;

    //
    int difficulty = 0;

    //
    public IntEvent DifficultyChanged;

    //
    public int Difficulty
    {
        get { return Singleton.difficulty; }
        set
        {
            DifficultyChanged.Invoke(value);
            difficulty = value;
        }
    }

    void Awake()
    {
        Singleton = this;
    }



}
