using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class CSV : SingletonMonoBehaviour<CSV>
{
    public void StartReading(string id, string name)
    {
        StartCoroutine(Method(id, name));
    }

    IEnumerator Method(string _SHEET_ID, string _SHEET_NAME)
    {
        UnityWebRequest request = UnityWebRequest.Get("https://docs.google.com/spreadsheets/d/" + _SHEET_ID + "/gviz/tq?tqx=out:csv&sheet=" + _SHEET_NAME);
        yield return request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            List<string[]> dataArrayList = ConvertToArrayListFrom(request.downloadHandler.text);
            foreach (string[] DataArray in dataArrayList)
            {
                WeponData characterData = new WeponData(DataArray);
            }
        }
    }

    List<string[]> ConvertToArrayListFrom(string _text)
    {
        List<string[]> characterDataArrayList = new List<string[]>();
        StringReader reader = new StringReader(_text);
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();        // àÍçsÇ∏Ç¬ì«Ç›çûÇ›
            string[] elements = line.Split(',');    // çsÇÃÉZÉãÇÕ,Ç≈ãÊêÿÇÁÇÍÇÈ
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] == "\"\"")
                {
                    continue;                       // ãÛîíÇÕèúãé
                }
                elements[i] = elements[i].TrimStart('"').TrimEnd('"');
            }
            characterDataArrayList.Add(elements);
        }
        return characterDataArrayList;
    }
}