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
        ;//Zkontroluje, zda je opera�n� syst�m va�eho po��ta�e v �esk�m jazyce
        if (Application.systemLanguage == SystemLanguage.Czech)
        {
            //Vyp�e do konzole, �e syst�m je v �e�tin�
            Debug.Log("Tento syst�m je v �e�tin�.");
        }
        else
        {
            //Vyp�e do konzole, �e syst�m je v �e�tin�
            Debug.Log("Tento syst�m neni v �e�tin�.");
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
        // odd�len� znak� od modifik�tor� (h��k�, ��rek, atd.)
        s = s.Normalize(System.Text.NormalizationForm.FormD);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {
            // do �et�zce p�id� v�echny znaky krom� modifik�tor�
            if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(s[i]) != System.Globalization.UnicodeCategory.NonSpacingMark)
            {
                sb.Append(s[i]);
            }
        }

        // vr�t� �et�zec bez diakritiky
        return sb.ToString();
    }

    /**public void OnClickButton()
    {
        Cursor.Current = Cursors.WaitCursor;
    }*/
}
