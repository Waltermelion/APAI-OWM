using System.Collections.Generic;

[System.Serializable]
public class Root2
{
    public List<Weather> weather ;
    public Main main ;
    public Wind wind ;
    public int timezone ;
    public string name ;
}

[System.Serializable]
public class Main
{
    public double temp ;
    public double feels_like ;
    public double temp_min ;
    public double temp_max ;
    public int humidity ;
}

[System.Serializable]
public class Weather
{
    public string main ;
    public string description ;
}

[System.Serializable]
public class Wind
{
    public double speed ;
    public int deg ;
}