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
