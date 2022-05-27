using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class apicalltest : MonoBehaviour
{
    private string endereco;
    private string owmAPIK = "956cd9bfca3e74fd6c75952e00d70685";
    //private string ggAPIK = "AIzaSyCWTazBRfJfzBHv4V-DQ8QmD0gNoy-nps0";
    private string geoNamesURL;

    void callApi(UnityEngine.UI.InputField query)
    {
        //https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=YOUR_API_KEY;
        //https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={API};
        endereco = UnityWebRequest.EscapeURL(query.text);
        geoNamesURL = "https://www.geonames.org/search.html?q=" + endereco + "&country=";        
        StartCoroutine(SendRequest());
    }
    IEnumerator SendRequest()
    {
        UnityWebRequest request = UnityWebRequest.Get("REQUEST_URL");
        yield return request.SendWebRequest();
    }
}