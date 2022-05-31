[System.Serializable]
public class GeonamesData
{
    public int totalResultsCount;
    public Geoname[] geonames;
}

[System.Serializable]
public class Geoname
{
    public string adminCode1;
    public string lng;
    public int geonameId;
    public string toponymName;
    public string countryId;
    public string fcl;
    public int population;
    public string countryCode;
    public string name;
    public string fclName;
    public Admincodes1 adminCodes1;
    public string countryName;
    public string fcodeName;
    public string adminName1;
    public string lat;
    public string fcode;
}

[System.Serializable]
public class Admincodes1
{
    public string ISO3166_2;
}
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Address
{
    public string adminCode2 { get; set; }
    public string adminCode3 { get; set; }
    public string adminCode1 { get; set; }
    public string lng { get; set; }
    public string houseNumber { get; set; }
    public string locality { get; set; }
    public string adminCode4 { get; set; }
    public string adminName2 { get; set; }
    public string street { get; set; }
    public string postalcode { get; set; }
    public string countryCode { get; set; }
    public string adminName1 { get; set; }
    public string lat { get; set; }
}

public class Root
{
    public Address address { get; set; }
}

