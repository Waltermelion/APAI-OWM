using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GeoNames : MonoBehaviour
{
    public string serviceLocation;
    public string service;
    public string username;
    public int maxRows = 10;
    [Space]
    [Space]
    public UnityEngine.UI.Text textArea;

    private GeonamesData data;

    // Start is called before the first frame update
    public void Search(UnityEngine.UI.InputField query)
    {
        string serviceURL = serviceLocation + "/" + service + "?q=" + query.text + "&maxRows=" + maxRows + "&username=" + username;


        StartCoroutine(SendQuery(serviceURL));
    }

    IEnumerator SendQuery(string URL)
    {
        // Debug.Log(URL);
        UnityWebRequest request = UnityWebRequest.Get(URL);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
            Debug.Log("Erro de comunicação");
        else
        {
            data = JsonUtility.FromJson<GeonamesData>(request.downloadHandler.text);
            showResults(data);
        }
    }

    private void showResults(GeonamesData data)
    {
        textArea.text = "Total Results: " + data.totalResultsCount;

        foreach (Geoname item in data.geonames)
        {
            textArea.text += "\n\tName: " + item.name;
        }
    }
}
