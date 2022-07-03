using ConsoleApp1;
/*
//1
Root requete11 = await Service.Requete("q=Kingdom of Morocco");
Console.WriteLine("Weather like in Kingdom of Morocco is "+requete11.weather[0].description);

Root requete12 = await Service.Requete("q=Morocco");
Console.WriteLine("Weather like in Morocco is "+requete12.weather[0].description);

//2
Root requete2 = await Service.Requete("q=Oslo");
DateTime dateTimeRise = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
dateTimeRise = dateTimeRise.AddSeconds(requete2.sys.sunrise).ToLocalTime();
DateTime dateTimeSet = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
dateTimeSet = dateTimeSet.AddSeconds(requete2.sys.sunset).ToLocalTime();
Console.WriteLine("Oslo sunrise "+ dateTimeRise + " / "+ "Oslo sun set "+ dateTimeSet );

//3
Root requete3 = await Service.Requete("q=Jakarta");
Console.WriteLine("Jakarta temperature is "+requete3.main.temp+ "°c");

//4
string[] country = {"New York City,us", "Tokyo,JP","Paris,FR"};
var a = 0.0;
var index = 0;
var b = 0;
foreach (string i in country) 
{
    Root requete4 = await Service.Requete("q="+i);
    if (a < requete4.wind.speed)
    {
        a = requete4.wind.speed;
        b = index;
    }
    index++;
}
Console.WriteLine("the place where there is the most wind "+country[b]+ " wind speed is "+ a);

//5
string[] country2 = {"Kyiv,UA","Moscow,RU","Berlin,DE"};
foreach (string i in country2) 
{
    Root requete5 = await Service.Requete("q="+i);
    Console.WriteLine(i+" pressure level: "+requete5.main.pressure+" hPa humidity level: "+requete5.main.humidity+"%");
}
*/
string[] country =
{"New York City,us", "Mexico City,MX", "Paris,FR", "São Paulo,BR", "Delhi,IN", "Seoul,KR", "Manila,PH", "Shanghai,CN",
    "Cairo,EG", "London,GB"};

void CurrentData(Root requete, string nameCountry)
{
    Console.WriteLine("\nWeather like in "+nameCountry+" with :"+requete.weather[0].description);
    DateTime dateTimeRise = new DateTime(1970, 1, 1, 0, 0, 0, 0, 
        DateTimeKind.Utc);
    dateTimeRise = dateTimeRise.AddSeconds(requete.sys.sunrise).ToLocalTime();
    DateTime dateTimeSet = new DateTime(1970, 1, 1, 0, 0, 0, 0, 
        DateTimeKind.Utc);
    dateTimeSet = dateTimeSet.AddSeconds(requete.sys.sunset).ToLocalTime();
    Console.WriteLine(nameCountry+" sunrise at "+ dateTimeRise + " / "+ nameCountry + " sunset at "+ dateTimeSet );
    Console.WriteLine(nameCountry +" temperature is "+requete.main.temp+ "°c"+ " temperature feels like "
                      +requete.main.feels_like+ "°c"); 
    Console.WriteLine("humidity is : " + requete.main.humidity + "% wind speed is : "+ requete.wind.speed +
                      "meter/sec wind gust is : "+ requete.wind.gust + "meter/sec");
}

void ForecastData(Root requeteForcast, string nameCountry)
{
    for (int i = 0; i < requeteForcast.list.Count; i++)
    {
        Console.WriteLine("\nWeather like in " + nameCountry + " at : "+ requeteForcast.list[i].dt_txt +" with " +
                          requeteForcast.list[i].weather[0].description);
        Console.WriteLine(nameCountry + " temperature is " + requeteForcast.list[i].main.temp + "°c" +
                          " temperature feels like  " + requeteForcast.list[i].main.feels_like + "°c" + 
                          " maximum temperature is "+ requeteForcast.list[i].main.temp_max+ "°c minimum temperature is "+
                          requeteForcast.list[i].main.temp_min+ "°c");
        Console.WriteLine("humidity is : " + requeteForcast.list[i].main.humidity + "% wind speed is : "+ 
                          requeteForcast.list[i].wind.speed + "meter/sec wind gust is : " + 
                          requeteForcast.list[i].wind.gust + "meter/sec" + " clouds :" +
                          requeteForcast.list[i].clouds.all+"%");
    }
    DateTime dateTimeRise = new DateTime(1970, 1, 1, 0, 0, 0, 0, 
        DateTimeKind.Utc);
    dateTimeRise = dateTimeRise.AddSeconds(requeteForcast.city.sunrise).ToLocalTime();
    DateTime dateTimeSet = new DateTime(1970, 1, 1, 0, 0, 0, 0, 
        DateTimeKind.Utc);
    dateTimeSet = dateTimeSet.AddSeconds(requeteForcast.city.sunset).ToLocalTime();
    Console.WriteLine(nameCountry + " sunrise at "+ dateTimeRise + " / "+ nameCountry + " sunset at "+ dateTimeSet );
        

}

async Task<bool> MainMenu()
{ 
    Console.Clear();
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1) \"New York City,us\"");
    Console.WriteLine("2) \"Mexico City,MX\"");
    Console.WriteLine("3) \"Paris,FR\"");
    Console.WriteLine("4) \"São Paulo,BR\"");
    Console.WriteLine("5) \"Delhi,IN\"");
    Console.WriteLine("6) \"Seoul,KR\"");
    Console.WriteLine("7) \"Manila,PH\"");
    Console.WriteLine("8) \"Shanghai,CN\"");
    Console.WriteLine("9) \"Cairo,EG\"");
    Console.WriteLine("10) \"London,GB\"");
    Console.WriteLine("11) Exit");
    Console.Write("\nSelect an option:\n>");
 
    switch (Console.ReadLine())
    {
        case "1":
            Root requete = await Service.Requete("q="+country[0]);
            Root requeteForcast = await Utils.Requete("q="+country[0]);
            Console.Clear();
            CurrentData(requete, country[0]);
            ForecastData(requeteForcast, country[0]);
            Console.WriteLine("\ntype [enter] to continue");
            Console.ReadLine();
            return true;
        case "2":
            Root requete1 = await Service.Requete("q=" + country[1]);
            Root requeteForcast1 = await Utils.Requete("q="+country[1]);
            Console.Clear();
            CurrentData(requete1, country[1]);
            ForecastData(requeteForcast1, country[1]);
            Console.WriteLine("\ntype [enter] to continue");
            Console.ReadLine();
            return true;
        case "3":
            Root requete2 = await Service.Requete("q=" + country[2]);
            Root requeteForcast2 = await Utils.Requete("q="+country[2]);
            Console.Clear();
            CurrentData(requete2, country[2]);
            ForecastData(requeteForcast2, country[2]);
            Console.WriteLine("\ntype [enter] to continue");
            Console.ReadLine();
            return true;
        case "4":
            Root requete3 = await Service.Requete("q=" + country[3]);
            Root requeteForcast3 = await Utils.Requete("q="+country[3]);
            Console.Clear();
            CurrentData(requete3, country[3]);
            ForecastData(requeteForcast3, country[3]);
            Console.WriteLine("\ntype [enter] to continue");
            Console.ReadLine();
            return true;
        case "5":
            Root requete4 = await Service.Requete("q=" + country[4]);
            Root requeteForcast4 = await Utils.Requete("q="+country[4]);
            Console.Clear();
            CurrentData(requete4, country[4]);
            ForecastData(requeteForcast4, country[4]);
            Console.WriteLine("\ntype [enter] to continue");
            Console.ReadLine();
            return true;
        case "6":
            Root requete5 = await Service.Requete("q=" + country[5]);
            Root requeteForcast5 = await Utils.Requete("q="+country[5]);
            Console.Clear();
            CurrentData(requete5, country[5]);
            ForecastData(requeteForcast5, country[5]);
            Console.WriteLine("\ntype [enter] to continue");
            Console.ReadLine();
            return true;
        case "7":
            Root requete6 = await Service.Requete("q=" + country[6]);
            Root requeteForcast6 = await Utils.Requete("q="+country[6]);
            Console.Clear();
            CurrentData(requete6, country[6]);
            ForecastData(requeteForcast6, country[6]);
            Console.WriteLine("\ntype [enter] to continue");
            Console.ReadLine();
            return true;
        case "8":
            Root requete7 = await Service.Requete("q=" + country[7]);
            Root requeteForcast7 = await Utils.Requete("q="+country[7]);
            Console.Clear();
            CurrentData(requete7, country[7]);
            ForecastData(requeteForcast7, country[7]);
            Console.WriteLine("\ntype [enter] to continue");
            Console.ReadLine();
            return true;
        case "9":
            Root requete8 = await Service.Requete("q=" + country[8]);
            Root requeteForcast8 = await Utils.Requete("q="+country[8]);
            Console.Clear();
            CurrentData(requete8, country[8]);
            ForecastData(requeteForcast8, country[8]);
            Console.WriteLine("\ntype [enter] to continue");
            Console.ReadLine();
            return true;
        case "10":
            Root requete9 = await Service.Requete("q=" + country[9]);
            Root requeteForcast9 = await Utils.Requete("q="+country[9]);
            Console.Clear();
            CurrentData(requete9, country[9]);
            ForecastData(requeteForcast9, country[9]);
            Console.WriteLine("\ntype [enter] to continue");
            Console.ReadLine();
            return true;
        default:
            Console.WriteLine("End of program!");
            return false;
    }
}
bool showMenu = true;
while (showMenu)
{
    showMenu = await MainMenu();
}