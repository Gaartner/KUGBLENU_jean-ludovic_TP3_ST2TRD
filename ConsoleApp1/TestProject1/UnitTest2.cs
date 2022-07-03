using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ConsoleApp1;
using NUnit.Framework;
using List = ConsoleApp1.List;

namespace TestProject1;

public class Tests2
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        //Assert.Pass();
        var wind = new Wind();
        var windDeg = wind.deg;
        Assert.AreEqual(typeof(int),windDeg.GetType());
    }
    [Test]
    public void Test2()
    {
        //Assert.Pass();
        var wind = new Wind();
        var windSpeed = wind.speed;
        Assert.AreEqual(typeof(double),windSpeed.GetType());
    }
    [Test]
    public void Test3()
    {
        //Assert.Pass();
        var wind = new Wind();
        var windGust = wind.gust;
        Assert.AreEqual(typeof(double),windGust.GetType());
    }
    [Test]
    public void Test4()
    {
        var sys = new Sys();
        var sysSunset = sys.sunset;
        Assert.AreEqual(typeof(int),sysSunset.GetType());
    }
    [Test]
    public void Test5()
    {
        var sys = new Sys();
        var sysSunrise = sys.sunrise;
        Assert.AreEqual(typeof(int),sysSunrise.GetType());
    }
    [Test]
    public async Task Test6()
    {
        Root requete = await Service.Requete("q=london");
        
        Assert.AreEqual(typeof(Root),requete.GetType());
    }
    [Test]
    public async Task Test7()
    {
        Root requete = await Utils.Requete("q=london");
        
        Assert.AreEqual(typeof(Root),requete.GetType());
    }
    [Test]
    public void Test9()
    {
        var clouds = new Clouds();
        var cloudsAll = clouds.all;
        Assert.AreEqual(typeof(int),cloudsAll.GetType());
    }
    [Test]
    public void Test10()
    {
        var city = new City();
        var citySunset = city.sunset;
        Assert.AreEqual(typeof(int),citySunset.GetType());
    }
    [Test]
    public void Test11()
    {
        var city = new City();
        var citySunrise = city.sunrise;
        Assert.AreEqual(typeof(int),citySunrise.GetType());
    }
}