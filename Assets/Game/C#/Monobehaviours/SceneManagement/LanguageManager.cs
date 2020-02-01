using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Singleton;

    //Language dictionaries
    public LanguageAssociation<string> tools;
    public LanguageAssociation<string> actions;

    void Awake()
    {
        Singleton = this;

        string[] toolstrings = { "hammer", "screwdriver", "wrench", "spanner" };
        string[] actionstrings = { "hit", "twist" };
        string[] nouns = GameIOFunctions.ReadNounList();
        tools = LanguageAssignment.AssociateLanguage<string>(nouns, toolstrings);
        actions = LanguageAssignment.AssociateLanguage<string>(nouns, actionstrings, tools.size);

        Debug.Log(tools.TranslateToAlien("hammer"));
        Debug.Log(tools.TranslateToAlien("screwdriver"));
        Debug.Log(tools.TranslateToAlien("wrench"));
        Debug.Log(tools.TranslateToAlien("spanner"));
        Debug.Log(actions.TranslateToAlien("hit"));
        Debug.Log(actions.TranslateToAlien("twist"));
    }

}
