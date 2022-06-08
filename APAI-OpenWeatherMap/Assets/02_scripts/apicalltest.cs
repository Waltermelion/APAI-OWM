using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class apicalltest : MonoBehaviour
{
    //Login
    [Header("Geonames Login")]
    public string usernome = "waltermelion";
    private string owmAPIK = "956cd9bfca3e74fd6c75952e00d70685";
    
    private string endereco;
    private string geoNamesURL;
    private Root root;
    
    //Area de texto no canvas
    [Header("Área de texto")]
    public Text textArea;
    public void callApi(InputField query)
    { 
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
            root = new Root();
            root = JsonUtility.FromJson<Root>(request.downloadHandler.text);
            textArea.text = "lat: " + root.address.lat + " lng: " + root.address.lng;
        }
    }
}