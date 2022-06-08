using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class apicalltest : MonoBehaviour
{
    //Login
    [Header("API Login")]
    public string geonamesUsernome = "waltermelion";
    private string geoNamesURL;
    public string owmAPIK = "956cd9bfca3e74fd6c75952e00d70685";
    private string owmURL;
    
    //Endereço + roots das Data sets
    private string endereco;
    private Root root;
    private Root2 root2;
    
    //[Header("Unidades de Medida")]
    //public string unidadesMedida = "metric";
    
    //Areas de texto no canvas
    [Header("Áreas de texto")]
    public Text placeName;
    public Text weatherDescription;
    public Text timeZone;
    public Text temp;
    public Text feelsLikeTemp;
    public Text minTemp;
    public Text maxTemp;
    public Text humidity;
    public Text windSpeed;
    
    public void callApi(InputField query)
    { 
        endereco = query.text.Replace(" ", "+");
        geoNamesURL = "http://api.geonames.org/geoCodeAddressJSON?q=" + endereco + "&username="+ geonamesUsernome;
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
            owmURL = "https://api.openweathermap.org/data/2.5/weather?lat=" + root.address.lat + "&lon=" + root.address.lng + "&units=metric" + "&appid=" + owmAPIK;
            request = UnityWebRequest.Get(owmURL);
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
                Debug.Log("Erro de comunicação: "+ request.error);
            else{
                root2 = new Root2();
                root2 = JsonUtility.FromJson<Root2>(request.downloadHandler.text);
                placeName.text = "The current weather for " + root2.name + " is:";
                weatherDescription.text = "Description: " + root2.weather[0].main + ", " + root2.weather[0].description;
                timeZone.text = "Timezone: " + root2.timezone;
                temp.text = "Temperature: " + root2.main.temp +"ºC";
                feelsLikeTemp.text = "Feels like: " + root2.main.feels_like + "ºC";
                minTemp.text = "Minimum: " + root2.main.temp_min + "°C";
                maxTemp.text = "Maximum: " + root2.main.temp_max + "°C";
                humidity.text = "Humidity: " + root2.main.humidity;
                windSpeed.text = "Wind Speed: " + root2.wind.speed + " mph, " + root2.wind.deg + " degrees.";
            }
        }
    }
}