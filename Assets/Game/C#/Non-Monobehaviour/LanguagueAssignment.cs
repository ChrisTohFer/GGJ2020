using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class LanguageAssociation<TYPE>
{
    Dictionary<string, TYPE> alienToType;
    Dictionary<TYPE, string> typeToAlien;

    public LanguageAssociation(Dictionary<string, TYPE> att, Dictionary<TYPE, string> tta)
    {
        alienToType = att;
        typeToAlien = tta;
    }
    
    public TYPE TranslateFromAlien(string str)
    {
        return alienToType[str];
    }
    public string TranslateToAlien(TYPE t)
    {
        return typeToAlien[t];
    }

}

class LanguageAssignment
{
    static void RandomizeStrings(string[] strings)
    {
        Random rng = new Random();

        //Copied from stack overflow boo yah
        int n = strings.Length;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            string value = strings[k];
            strings[k] = strings[n];
            strings[n] = value;
        }
    }

    public static LanguageAssociation<TYPE> AssociateLanguage<TYPE>(string[] alien, TYPE[] objects)
    {
        Dictionary<string, TYPE> alienToType = new Dictionary<string, TYPE>();
        Dictionary<TYPE, string> typeToAlien = new Dictionary<TYPE, string>();

        RandomizeStrings(alien);
        
        for(int i = 0; i < objects.Length; ++i)
        {
            string word;
            if (alien.Length > i)
            {
                word = alien[i];
            }
            else
                word = "MISSING_WORD";

            alienToType.Add(word, objects[i]);
            typeToAlien.Add(objects[i], word);
        }

        return new LanguageAssociation<TYPE>(alienToType, typeToAlien);
    }
}
