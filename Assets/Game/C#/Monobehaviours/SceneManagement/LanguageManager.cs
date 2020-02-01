using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Singleton;

    //Arrays of english terms
    [SerializeField] string[] socketNames;
    [SerializeField] string[] componentNames;
    [SerializeField] string[] toolNames;

    //Language dictionaries
    public LanguageAssociation<string> sockets;
    public LanguageAssociation<string> components;
    public LanguageAssociation<string> tools;

    void Awake()
    {
        Singleton = this;

        string[] nouns = GameIOFunctions.ReadNounList();

        sockets = LanguageAssignment.AssociateLanguage<string>(nouns, socketNames);
        components = LanguageAssignment.AssociateLanguage<string>(nouns, componentNames, sockets.size);
        tools = LanguageAssignment.AssociateLanguage<string>(nouns, toolNames, sockets.size + components.size);
    }

}
