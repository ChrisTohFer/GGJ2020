using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageAssociation<TYPE>
{
    //Member objects
    Dictionary<string, TYPE> alienToType;
    Dictionary<TYPE, string> typeToAlien;

    //Properties
    public int size
    {
        get { return alienToType.Count; }
    }

    public LanguageAssociation(Dictionary<string, TYPE> att, Dictionary<TYPE, string> tta)
    {
        alienToType = att;
        typeToAlien = tta;
    }
    
    //Translation methods

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
    //Function associates a list of alien words with a list of objects, with the option to begin partway through the word list
    public static LanguageAssociation<TYPE> AssociateLanguage<TYPE>(string[] alien, TYPE[] objects, int readfrom = 0)
    {
        Dictionary<string, TYPE> alienToType = new Dictionary<string, TYPE>();
        Dictionary<TYPE, string> typeToAlien = new Dictionary<TYPE, string>();
        
        for(int i = 0; i < objects.Length; ++i)
        {
            string word;
            if (alien.Length > i + readfrom)
            {
                word = alien[i + readfrom];
            }
            else
                word = "MISSING_WORD" + i;

            alienToType.Add(word, objects[i]);
            typeToAlien.Add(objects[i], word);
        }

        return new LanguageAssociation<TYPE>(alienToType, typeToAlien);
    }
}
