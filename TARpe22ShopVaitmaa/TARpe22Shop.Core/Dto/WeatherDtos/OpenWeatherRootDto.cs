using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TARpe22ShopVaitmaa.Core.Dto.WeatherDtos
{
    public class OpenWeatherRootDto
    {

        [JsonPropertyName("weather")]
        public List<Weather> Weather { get; set; }

        [JsonPropertyName("@base")]
        public string AtBase { get; set; }

        [JsonPropertyName("main")]
        public Main Main { get; set; }

        [JsonPropertyName("coord")]
        public Coord Coord { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("wind")]
        public Winds Wind { get; set; }

        [JsonPropertyName("rain")]
        public Rains Rain { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

        [JsonPropertyName("dt")]
        public int DT { get; set; }

        [JsonPropertyName("sys")]
        public Syss Sys { get; set; }

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("cod")]
        public int Cod { get; set; }
    }
}
public class Clouds
{

    [JsonPropertyName("all")]
    public int All { get; set; }
}


public class Main
{

    [JsonPropertyName("temp")]
    public double Temp { get; set; }

    [JsonPropertyName("feels_like")]
    public double FeelsLike { get; set; }

    [JsonPropertyName("temp_min")]
    public double TempMin { get; set; }

    [JsonPropertyName("temp_max")]
    public double TempMax { get; set; }

    [JsonPropertyName("pressure")]
    public int Pressure { get; set; }

    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }

    [JsonPropertyName("sea_level")]
    public int SeaLevel { get; set; }

    [JsonPropertyName("grnd_level")]
    public int GroundLevel { get; set; }
}

public class Rains
{

    [JsonPropertyName("_1h")]
    public double _1h { get; set; }
}

public class Syss
{

    [JsonPropertyName("type")]
    public int Type { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("sunrise")]
    public int Sunrise { get; set; }

    [JsonPropertyName("sunset")]
    public int Sunset { get; set; }
}

public class Weather
{

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("main")]
    public string Main { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }
}

public class Winds
{

    [JsonPropertyName("speed")]
    public double Speed { get; set; }

    [JsonPropertyName("deg")]
    public int Deg { get; set; }

    [JsonPropertyName("gust")]
    public double Gust { get; set; }
}

public class Coord
{
    [JsonPropertyName("lon")]
    public double Lon { get; set; }

    [JsonPropertyName("lat")]
    public double Lat { get; set; }
}