using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class apicalltest : MonoBehaviour
{
    public string usernome = "waltermelion";
    private string endereco;
    private string owmAPIK = "956cd9bfca3e74fd6c75952e00d70685";
    //private string ggAPIK = "AIzaSyCWTazBRfJfzBHv4V-DQ8QmD0gNoy-nps0";
    
    private string geoNamesURL;
    private Address data;

    public Text textArea;

    public void callApi(InputField query)
    {
        //https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={API};
        //endereco = UnityWebRequest.EscapeURL(query.text);
        endereco = query.text.Replace(" ", "+");
        geoNamesURL = "http://api.geonames.org/geoCodeAddressJSON?q=" + endereco + "&username="+ usernome;
        Debug.Log(geoNamesURL);
        
        StartCoroutine(SendRequest(geoNamesURL));
    }
    IEnumerator SendRequest(string URL)
    {
        UnityWebRequest request = UnityWebRequest.Get(URL);
        
        yield return request.SendWebRequest();
        
        if (request.result != UnityWebRequest.Result.Success)
            Debug.Log("Erro de comunicação: "+ request.error);
        else
        {
            data = JsonUtility.FromJson<Address>(request.downloadHandler.text);
            textArea.text = data.ToString();
            //showResults(data);
        }
    }
    private void showResults(GeonamesData data)
    {
        textArea.text = "Total Results: " + data;

        
            //textArea.text += "\n\tName: " + item.name;
        
    }
}