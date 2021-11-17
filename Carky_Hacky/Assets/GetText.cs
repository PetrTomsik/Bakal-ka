using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine;
using System.Linq;
using System.Text;
using System;

public class GetText : MonoBehaviour
{
    public Transform contentWindow;
    public GameObject recallTextObject;
    // Start is called before the first frame update
    void Start()
    {
        ;//Zkontroluje, zda je operaèní systém vašeho poèítaèe v èeském jazyce
        if (Application.systemLanguage == SystemLanguage.Czech)
        {
            //Vypíše do konzole, že systém je v èeštinì
            Debug.Log("Tento systém je v èeštinì.");
        }
        else
        {
            //Vypíše do konzole, že systém je v èeštinì
            Debug.Log("Tento systém neni v èeštinì.");
        }

        string readFilePath = "D:/Unity_Zkoska/Hacky/Assets/StreamingAssents/Recall_Chat/" + "Prvni.txt";
        StreamReader sr;
        try
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (sr = new StreamReader(readFilePath, Encoding.GetEncoding(1250)))/**cesky jazyk je pod 1250 Win - stredoevropsky*/
            {
                string line= null;
                string lineWithCommasAndHooks = null;
                string lineWithoutCommasAndHooks = null;
                // Read and display lines from the file until the end of
                // the file is reached.

                while ((line = sr.ReadLine()) != null)
                {
                    Debug.Log(line);
                    lineWithCommasAndHooks += RemoveDiacritics(line + "\n");
                    lineWithoutCommasAndHooks +=line + "\n";
                    Debug.Log(lineWithCommasAndHooks);

                }
                Instantiate(recallTextObject, contentWindow);
                recallTextObject.GetComponent<Text>().text =lineWithCommasAndHooks ;


            }
            sr.Close();
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Debug.Log("The file could not be read:");
            Debug.Log(e.Message);
        }
    }

    // Update is called once per frame
    public string RemoveDiacritics(String s)
    {
        // oddìlení znakù od modifikátorù (háèkù, èárek, atd.)
        s = s.Normalize(System.Text.NormalizationForm.FormD);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {
            // do øetìzce pøidá všechny znaky kromì modifikátorù
            if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(s[i]) != System.Globalization.UnicodeCategory.NonSpacingMark)
            {
                sb.Append(s[i]);
            }
        }

        // vrátí øetìzec bez diakritiky
        return sb.ToString();
    }

    /**public void OnClickButton()
    {
        Cursor.Current = Cursors.WaitCursor;
    }*/
}
