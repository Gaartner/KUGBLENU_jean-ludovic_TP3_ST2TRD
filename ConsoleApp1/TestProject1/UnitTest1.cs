using System.Diagnostics;
using ConsoleApp1;
using NUnit.Framework;
using List = ConsoleApp1.List;

namespace TestProject1;

public class Tests
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
        Debug.Assert(wind != null, nameof(wind) + " != null");
    }
    [Test]
    public void Test2()
    {
        //Assert.Pass();
        var sys = new Sys();
        Debug.Assert(sys != null, nameof(sys) + " != null");
    }
    [Test]
    public void Test3()
    {
        //Assert.Pass();
        var root = new Root();
        Debug.Assert(root != null, nameof(root) + " != null");
    }
    [Test]
    public void Test4()
    {
        //Assert.Pass();
        var rain = new Rain();
        Debug.Assert(rain != null, nameof(rain) + " != null");
    }
    [Test]
    public void Test5()
    {
        //Assert.Pass();
        var main = new Main();
        Debug.Assert(main != null, nameof(main) + " != null");
    }
    [Test]
    public void Test6()
    {
        //Assert.Pass();
        var list = new List();
        Debug.Assert(list != null, nameof(list) + " != null");
    }
    [Test]
    public void Test7()
    {
        //Assert.Pass();
        var coord = new Coord();
        Debug.Assert(coord != null, nameof(coord) + " != null");
    }
    [Test]
    public void Test8()
    {
        //Assert.Pass();
        var clouds = new Clouds();
        Debug.Assert(clouds != null, nameof(clouds) + " != null");
    }
    [Test]
    public void Test9()
    {
        //Assert.Pass();
        var city = new City();
        Debug.Assert(city != null, nameof(city) + " != null");
    }
}