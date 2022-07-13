using System;
using System.Diagnostics;
using MacOSApp1;
using NUnit.Framework;

namespace UITestProject1
{
    public class Unittest3
    {
        [Test]
            public void Forecast1()
            {
                //Assert.Pass();
                var wind = new Forecast.Wind();
                Debug.Assert(wind != null, nameof(wind) + " != null");
            }
            [Test]
            public void ForecastSys2()
            {
                //Assert.Pass();
                var sys = new Forecast.Sys();
                Debug.Assert(sys != null, nameof(sys) + " != null");
            }
            [Test]
            public void ForecastRoot3()
            {
                //Assert.Pass();
                var root = new Forecast.Root();
                Debug.Assert(root != null, nameof(root) + " != null");
            }
            [Test]
            public void ForecastRain4()
            {
                //Assert.Pass();
                var rain = new Forecast.Rain();
                Debug.Assert(rain != null, nameof(rain) + " != null");
            }
            [Test]
            public void ForecastMain5()
            {
                //Assert.Pass();
                var main = new Forecast.Main();
                Debug.Assert(main != null, nameof(main) + " != null");
            }
            [Test]
            public void ForecastList6()
            {
                //Assert.Pass();
                var list = new List();
                Debug.Assert(list != null, nameof(list) + " != null");
            }
            [Test]
            public void ForecastCoord7()
            {
                //Assert.Pass();
                var coord = new Forecast.Coord();
                Debug.Assert(coord != null, nameof(coord) + " != null");
            }
            [Test]
            public void ForecastClouds8()
            {
                //Assert.Pass();
                var clouds = new Forecast.Clouds();
                Debug.Assert(clouds != null, nameof(clouds) + " != null");
            }
            [Test]
            public void ForecastCity9()
            {
                //Assert.Pass();
                var city = new Forecast.City();
                Debug.Assert(city != null, nameof(city) + " != null");
            }
            [Test]
            public void ForecastWeather9()
            {
                //Assert.Pass();
                var weather = new Forecast.Weather();
                Debug.Assert(weather != null, nameof(weather) + " != null");
            }
            [Test]
            public void AirpolutionCompenent()
            {
                //Assert.Pass();
                var air = new Airpolution.Components();
                Debug.Assert(air != null, nameof(air) + " != null");
            }

            [Test]
            public void Pressure()
            {
                Assert.That(1015 +"hpa: good weather",Is.EqualTo(getPressure(1015)));
            }

            [Test]
            public void GetDate()
            {
                DateTime d = new DateTime(2022,03,15,13,00,00,000);
                Assert.That(d, Is.EqualTo(getDate(1647345600)));
            }
            public DateTime getDate(double time)
            {
                DateTime day =  new DateTime(1970, 1, 1, 0, 0, 0, 0, 
                    DateTimeKind.Utc);
                day = day.AddSeconds(time).ToLocalTime();
                return day;
            }

            private string getPressure(int pressure)
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
    }
}