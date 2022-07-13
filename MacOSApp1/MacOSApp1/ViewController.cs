using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AppKit;
using Foundation;

namespace MacOSApp1
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public String getPressure(int pressure)
        {
            if (pressure >= 1015)
            {
                return pressure +"hpa: good weather";
            }
            else if (pressure <  980)
            {
                return  pressure +"hpa: Storm Alert";
            }
            else if (pressure <  1000)
            {
                return  pressure +"hpa: rain is coming risk of storm";
            }

            return "normal weather";
        }
        public DateTime getDate(double time)
        {
            DateTime day =  new DateTime(1970, 1, 1, 0, 0, 0, 0, 
                DateTimeKind.Utc);
            day = day.AddSeconds(time).ToLocalTime();
            return day;
        }
        void CurrentData(Weather.Root requete, string nameCountry)
        {
            Console.WriteLine("\nWeather like in " + nameCountry + " with :" + requete.weather[0].description);
            DateTime dateTimeCurrent = getDate(requete.dt);
            DateTime dateTimeRise = getDate(requete.sys.sunrise);
            DateTime dateTimeSet = getDate(requete.sys.sunset);
            Console.WriteLine(nameCountry+" sunrise at "+ dateTimeRise + " / "+ nameCountry + " sunset at "+ 
                              dateTimeSet);
            Console.WriteLine(nameCountry +" temperature is "+requete.main.temp+ "°c"+ " temperature feels like "
                              +requete.main.feels_like+ "°c");
            Console.WriteLine("humidity is : " + requete.main.humidity + "% wind speed is : " + requete.wind.speed);
            sunset.StringValue = dateTimeRise.ToString("HH:mm:ss")+"PM";
            location.StringValue = nameCountry;
            date.StringValue = dateTimeCurrent.ToString("yyyy-M-d dddd");
            temperature.StringValue = requete.main.temp.ToString()+" °C";
            sunrise.StringValue = dateTimeSet.ToString("HH:mm:ss")+"AM";
            weatherDescription.StringValue = requete.weather[0].description;
            windSpeed.StringValue = requete.wind.speed.ToString()+" meter/sec ";
            icon1.Image = new NSImage(requete.weather[0].icon+".png");
            temperatureMinMax.StringValue = requete.main.temp_min + "°c / " + requete.main.temp_max + "°c";
            temperatureFeel.StringValue = requete.main.feels_like + "°c";
            pressure.StringValue = getPressure(requete.main.pressure);
        }
        
        void ForecastData(Forecast.Root requeteForcast, string nameCountry)
        {
            for (int i = 0; i < requeteForcast.list.Count; i++)
            {
                Console.WriteLine("\nWeather like in " + nameCountry + " at : " + requeteForcast.list[i].dt_txt +
                                  " with " +
                                  requeteForcast.list[i].weather[0].description);
                Console.WriteLine(nameCountry + " temperature is " + requeteForcast.list[i].main.temp + "°c" +
                                  " temperature feels like  " + requeteForcast.list[i].main.feels_like + "°c" +
                                  " maximum temperature is " + requeteForcast.list[i].main.temp_max +
                                  "°c minimum temperature is " +
                                  requeteForcast.list[i].main.temp_min + "°c");
                Console.WriteLine("humidity is : " + requeteForcast.list[i].main.humidity + "% wind speed is : " +
                                  requeteForcast.list[i].wind.speed + "meter/sec wind gust is : " +
                                  requeteForcast.list[i].wind.gust + "meter/sec" + " clouds :" +
                                  requeteForcast.list[i].clouds.all + "%");
            }
            
            for ( int i = 0; i < requeteForcast.list.Count; i++)
            {
                var localDate = DateTime.Now;
                
                var tommorow = Regex.Split(requeteForcast.list[i].dt_txt, @"\s+");
                if (tommorow[0] == localDate.AddDays(1).ToString("yyyy-MM-dd"))
                {
                    var time1 = getDate(requeteForcast.list[i].dt);
                    days2.StringValue = time1.DayOfWeek.ToString();
                    if (tommorow[1] == "09:00:00")
                    {
                        image1.Image = new NSImage(requeteForcast.list[i].weather[0].icon + ".png");
                        minmax1.StringValue = requeteForcast.list[i].main.temp_max.ToString() + "°c / " +
                                              requeteForcast.list[i].main.temp_min.ToString() + "°c";
                        heure1.StringValue = requeteForcast.list[i].dt_txt
                            .Substring(requeteForcast.list[i].dt_txt.Length - 8);
                        
                    }
                    if (tommorow[1] == "15:00:00")
                    {
                        image2.Image = new NSImage(requeteForcast.list[i].weather[0].icon + ".png");
                        minmax2.StringValue = requeteForcast.list[i].main.temp_max.ToString() + "°c / " +
                                              requeteForcast.list[i].main.temp_min.ToString() + "°c";
                        heure2.StringValue = requeteForcast.list[i].dt_txt
                            .Substring(requeteForcast.list[i].dt_txt.Length - 8);
                        
                    }

                    if (tommorow[1] == "21:00:00")
                    {
                        image3.Image = new NSImage(requeteForcast.list[i].weather[0].icon + ".png");
                        minmax3.StringValue = requeteForcast.list[i].main.temp_max.ToString() + "°c / " +
                                              requeteForcast.list[i].main.temp_min.ToString() + "°c";
                        heure3.StringValue = requeteForcast.list[i].dt_txt
                            .Substring(requeteForcast.list[i].dt_txt.Length - 8);
                        
                    }
                    
                }
                //2
                if (tommorow[0] == localDate.AddDays(2).ToString("yyyy-MM-dd"))
                {
                    var time2 = getDate(requeteForcast.list[i].dt);
                    days3.StringValue = time2.DayOfWeek.ToString();
                    if (tommorow[1] == "09:00:00")
                    {
                        image4.Image = new NSImage(requeteForcast.list[i].weather[0].icon + ".png");
                        minmax4.StringValue = requeteForcast.list[i].main.temp_max.ToString() + "°c / " +
                                              requeteForcast.list[i].main.temp_min.ToString() + "°c";

                    }
                    if (tommorow[1] == "15:00:00")
                    {
                        image5.Image = new NSImage(requeteForcast.list[i].weather[0].icon + ".png");
                        minmax5.StringValue = requeteForcast.list[i].main.temp_max.ToString() + "°c / " +
                                              requeteForcast.list[i].main.temp_min.ToString() + "°c";

                    }

                    if (tommorow[1] == "21:00:00")
                    {
                        image6.Image = new NSImage(requeteForcast.list[i].weather[0].icon + ".png");
                        minmax6.StringValue = requeteForcast.list[i].main.temp_max.ToString() + "°c / " +
                                              requeteForcast.list[i].main.temp_min.ToString() + "°c";
                        
                        
                    }
                    
                }
                //3
                if (tommorow[0] == localDate.AddDays(3).ToString("yyyy-MM-dd"))
                {
                    var time3 = getDate(requeteForcast.list[i].dt);
                    days4.StringValue = time3.DayOfWeek.ToString();
                    if (tommorow[1] == "09:00:00")
                    {
                        image7.Image = new NSImage(requeteForcast.list[i].weather[0].icon + ".png");
                        minmax7.StringValue = requeteForcast.list[i].main.temp_max.ToString() + "°c / " +
                                              requeteForcast.list[i].main.temp_min.ToString() + "°c";

                    }
                    if (tommorow[1] == "15:00:00")
                    {
                        image8.Image = new NSImage(requeteForcast.list[i].weather[0].icon + ".png");
                        minmax8.StringValue = requeteForcast.list[i].main.temp_max.ToString() + "°c / " +
                                              requeteForcast.list[i].main.temp_min.ToString() + "°c";

                    }

                    if (tommorow[1] == "21:00:00")
                    {
                        image9.Image = new NSImage(requeteForcast.list[i].weather[0].icon + ".png");
                        minmax9.StringValue = requeteForcast.list[i].main.temp_max.ToString() + "°c / " +
                                              requeteForcast.list[i].main.temp_min.ToString() + "°c";
                        
                        
                    }
                    
                }
                //3
                if (tommorow[0] == localDate.AddDays(4).ToString("yyyy-MM-dd"))
                {
                    var time4 = getDate(requeteForcast.list[i].dt);
                    days5.StringValue = time4.DayOfWeek.ToString();
                    if (tommorow[1] == "09:00:00")
                    {
                        image10.Image = new NSImage(requeteForcast.list[i].weather[0].icon + ".png");
                        minmax10.StringValue = requeteForcast.list[i].main.temp_max.ToString() + "°c / " +
                                              requeteForcast.list[i].main.temp_min.ToString() + "°c";

                    }
                    if (tommorow[1] == "15:00:00")
                    {
                        image11.Image = new NSImage(requeteForcast.list[i].weather[0].icon + ".png");
                        minmax11.StringValue = requeteForcast.list[i].main.temp_max.ToString() + "°c / " +
                                              requeteForcast.list[i].main.temp_min.ToString() + "°c";

                    }

                    if (tommorow[1] == "21:00:00")
                    {
                        image12.Image = new NSImage(requeteForcast.list[i].weather[0].icon + ".png");
                        minmax12.StringValue = requeteForcast.list[i].main.temp_max.ToString() + "°c / " +
                                              requeteForcast.list[i].main.temp_min.ToString() + "°c";
                        
                        
                    }
                    
                }
                //3
                if (tommorow[0] == localDate.AddDays(5).ToString("yyyy-MM-dd"))
                {
                    var time5 = getDate(requeteForcast.list[i].dt);
                    days6.StringValue = time5.DayOfWeek.ToString();
                    if (tommorow[1] == "09:00:00")
                    {
                        image13.Image = new NSImage(requeteForcast.list[i].weather[0].icon + ".png");
                        minmax13.StringValue = requeteForcast.list[i].main.temp_max.ToString() + "°c / " +
                                               requeteForcast.list[i].main.temp_min.ToString() + "°c";

                    }
                    if (tommorow[1] == "15:00:00")
                    {
                        image14.Image = new NSImage(requeteForcast.list[i].weather[0].icon + ".png");
                        minmax14.StringValue = requeteForcast.list[i].main.temp_max.ToString() + "°c / " +
                                               requeteForcast.list[i].main.temp_min.ToString() + "°c";

                    }

                    if (tommorow[1] == "21:00:00")
                    {
                        image15.Image = new NSImage(requeteForcast.list[i].weather[0].icon + ".png");
                        minmax15.StringValue = requeteForcast.list[i].main.temp_max.ToString() + "°c / " +
                                               requeteForcast.list[i].main.temp_min.ToString() + "°c";
                        
                        
                    }
                    
                }

                    /*if (requeteForcast.list[i].dt_txt.Contains())
                {
                    var time1 = getDate(requeteForcast.list[i].dt);
                    days2.StringValue = time1.DayOfWeek.ToString();
                    image1.Image = new NSImage(requeteForcast.list[i].weather[0].icon + ".png");
                    image2.Image = new NSImage(requeteForcast.list[i+2].weather[0].icon + ".png");
                    image3.Image = new NSImage(requeteForcast.list[i+3].weather[0].icon + ".png");
                    minmax1.StringValue = requeteForcast.list[i].main.temp_max.ToString() + "°c / " +
                                          requeteForcast.list[i].main.temp_min.ToString() + "°c";
                    minmax2.StringValue = requeteForcast.list[i+2].main.temp_max.ToString() + "°c / " +
                                          requeteForcast.list[i+2].main.temp_min.ToString() + "°c";
                    minmax3.StringValue = requeteForcast.list[i+3].main.temp_max.ToString() + "°c / " +
                                          requeteForcast.list[i+3].main.temp_min.ToString() + "°c";
                    heure1.StringValue = requeteForcast.list[i].dt_txt
                        .Substring(requeteForcast.list[i].dt_txt.Length - 8);
                    heure2.StringValue = requeteForcast.list[i+2].dt_txt
                        .Substring(requeteForcast.list[i+2].dt_txt.Length - 8);
                    heure3.StringValue = requeteForcast.list[i+3].dt_txt
                        .Substring(requeteForcast.list[i+3].dt_txt.Length - 8);
                    
                    //3
                    time1 = getDate(requeteForcast.list[i + 8].dt);
                    days3.StringValue = time1.DayOfWeek.ToString();
                    image4.Image = new NSImage(requeteForcast.list[i+8].weather[0].icon + ".png");
                    image5.Image = new NSImage(requeteForcast.list[i+10].weather[0].icon + ".png");
                    image6.Image = new NSImage(requeteForcast.list[i+11].weather[0].icon + ".png");
                    minmax4.StringValue = requeteForcast.list[i+8].main.temp_max.ToString() + "°c / " +
                                          requeteForcast.list[i+8].main.temp_min.ToString() + "°c";
                    minmax5.StringValue = requeteForcast.list[i+10].main.temp_max.ToString() + "°c / " +
                                          requeteForcast.list[i+10].main.temp_min.ToString() + "°c";
                    minmax6.StringValue = requeteForcast.list[i+11].main.temp_max.ToString() + "°c / " +
                                          requeteForcast.list[i+11].main.temp_min.ToString() + "°c";
                    
                    //4
                    time1 = getDate(requeteForcast.list[i + 16].dt);
                    days4.StringValue = time1.DayOfWeek.ToString();
                    image7.Image = new NSImage(requeteForcast.list[i+16].weather[0].icon + ".png");
                    image8.Image = new NSImage(requeteForcast.list[i+18].weather[0].icon + ".png");
                    image9.Image = new NSImage(requeteForcast.list[i+19].weather[0].icon + ".png");
                    minmax7.StringValue = requeteForcast.list[i+16].main.temp_max.ToString() + "°c / " +
                                          requeteForcast.list[i+16].main.temp_min.ToString() + "°c";
                    minmax8.StringValue = requeteForcast.list[i+18].main.temp_max.ToString() + "°c / " +
                                          requeteForcast.list[i+18].main.temp_min.ToString() + "°c";
                    minmax9.StringValue = requeteForcast.list[i+19].main.temp_max.ToString() + "°c / " +
                                          requeteForcast.list[i+19].main.temp_min.ToString() + "°c";
                    
                    //5
                    time1 = getDate(requeteForcast.list[i + 24].dt);
                    days5.StringValue = time1.DayOfWeek.ToString();
                    image10.Image = new NSImage(requeteForcast.list[i+24].weather[0].icon + ".png");
                    image11.Image = new NSImage(requeteForcast.list[i+26].weather[0].icon + ".png");
                    image12.Image = new NSImage(requeteForcast.list[i+27].weather[0].icon + ".png");
                    minmax10.StringValue = requeteForcast.list[i+24].main.temp_max.ToString() + "°c / " +
                                          requeteForcast.list[i+24].main.temp_min.ToString() + "°c";
                    minmax11.StringValue = requeteForcast.list[i+26].main.temp_max.ToString() + "°c / " +
                                          requeteForcast.list[i+26].main.temp_min.ToString() + "°c";
                    minmax12.StringValue = requeteForcast.list[i+27].main.temp_max.ToString() + "°c / " +
                                          requeteForcast.list[i+27].main.temp_min.ToString() + "°c";
                    
                    //6
                   
                    time1 = getDate(requeteForcast.list[i + 32].dt);
                    days6.StringValue = time1.DayOfWeek.ToString();
                    image13.Image = new NSImage(requeteForcast.list[i+32].weather[0].icon + ".png");
                    image14.Image = new NSImage(requeteForcast.list[i+34].weather[0].icon + ".png");
                    image15.Image = new NSImage(requeteForcast.list[i+35].weather[0].icon + ".png");
                    minmax13.StringValue = requeteForcast.list[i+32].main.temp_max.ToString() + "°c / " +
                                           requeteForcast.list[i+32].main.temp_min.ToString() + "°c";
                   minmax14.StringValue = requeteForcast.list[i+34].main.temp_max.ToString() + "°c / " +
                                          requeteForcast.list[i+34].main.temp_min.ToString() + "°c";
                   minmax15.StringValue = requeteForcast.list[i+35].main.temp_max.ToString() + "°c / " +
                                          requeteForcast.list[i+35].main.temp_min.ToString() + "°c";
                    
                    break;
                }*/
            }

        }

        void AirPolutionData(Airpolution.Root requeteAirPolution)
        {
            switch(requeteAirPolution.list[0].main.aqi.ToString()) 
            {
                case "1":
                    airQuality.StringValue = "air quality: GOOD";
                    break;
                case "2":
                    airQuality.StringValue = "air quality: FAIR";
                    break;
                case "3":
                    airQuality.StringValue = "air quality: MODERATE";
                    break;
                case "4":
                    airQuality.StringValue = "air quality: POOR";
                    break;
                case "5":
                    airQuality.StringValue = "air quality: VERY POOR";
                    break;
                default:
                    airQuality.StringValue = "air quality: ERROR";
                    break;
            }
            Console.WriteLine("quality :"+requeteAirPolution.list[0].main.aqi);
        }
        public async Task hey()
        {
            string[] country =
            {"New York City,us", "Mexico City,MX", "Paris,FR", "São Paulo,BR", "Delhi,IN", "Seoul,KR", 
                "Manila,PH", "Shanghai,CN", "Cairo,EG", "London,GB"};
            //string test = search.StringValue;
            int test = Int16.Parse( search.StringValue); 
            Console.WriteLine("hey:"+test);
            Weather.Root requeteWeather = await Service.RequeteWeather("q=" + country[test]);
            
            Forecast.Root requeteForcast = await Service.RequeteForecast("q=" + country[test]);
            Airpolution.Root requeteAirPolution = await Service.RequeteAirPolution(requeteWeather.coord.lat,
                requeteWeather.coord.lon);
            CurrentData(requeteWeather, country[test]);
            ForecastData(requeteForcast, country[test]);
            AirPolutionData(requeteAirPolution);
        }


        async partial void run (Foundation.NSObject sender)
        {
            await hey();


        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            textMenu.StringValue = "Select an option: \"(ex: \"1\" for New-York)\"\n"+
                "0\" New York City,us, 1\"Mexico City,MX , 2\"Paris,FR, 3\"São Paulo,BR, 4\"Delhi,IN 5\"Seoul,KR," +
                " 6\"Manila,PH, 7\"Shanghai,CN,8\"Cairo,EG, 9\"London,GB";
            // Do any additional setup after loading the view.
        }

        public override NSObject RepresentedObject
        {
            get { return base.RepresentedObject; }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}