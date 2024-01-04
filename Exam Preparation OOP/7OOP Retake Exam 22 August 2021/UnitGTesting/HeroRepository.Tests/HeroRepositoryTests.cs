using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{

    
    [Test]
    public void Constructor_Testing()
    {
        Hero hero = new Hero("lasi", 5);
        Assert.AreEqual("lasi",hero.Name);
        Assert.AreEqual(5, hero.Level);
    }
    [Test]
    public void CreatedHeros()
    {
        HeroRepository heros = new HeroRepository();
        Hero hero = new Hero("lasi", 5);
        Hero hero1 = new Hero("basi", 6);
        Hero hero2 = new Hero("masi", 6);
        heros.Create(hero);
        Assert.AreEqual(1,heros.Heroes.Count);
        heros.Create(hero1);
        heros.Create(hero2);
        Assert.AreEqual(3, heros.Heroes.Count);
      

    }
    [TestCase(null)]
    public void CreatedHeros_invalidName(Hero hero)
    {
        HeroRepository heros = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() => heros.Create(hero), $"Hero is null");
        


    }
    [Test]
    public void CreatedexistingHero()
    {
        HeroRepository heros = new HeroRepository();
        Hero hero = new Hero("lasi", 5);
        Hero hero1 = new Hero("basi", 6);
        Hero hero2 = new Hero("masi", 6);
        heros.Create(hero);
        heros.Create(hero1);
        heros.Create(hero2);
        Assert.Throws<InvalidOperationException>(() => heros.Create(hero), $"Hero with name lasi already exists");


    }
    [Test]
    public void SucssesCreatedHeros()
    {
        HeroRepository heros = new HeroRepository();
        Hero hero = new Hero("lasi", 5);
        Hero hero1 = new Hero("basi", 6);
        Hero hero2 = new Hero("masi", 6);
        heros.Create(hero);
        Assert.AreEqual(1, heros.Heroes.Count);
        var createdhero = hero;
        Assert.AreEqual("lasi", createdhero.Name);
        Assert.AreEqual(5, createdhero.Level);
    }
    [TestCase(null)]
    [TestCase(" ")]
    public void Removed_invalidHero(string name)
    {
        HeroRepository heros = new HeroRepository();
        Hero hero = new Hero("lasi", 5);
        Hero hero1 = new Hero("basi", 6);
        Hero hero2 = new Hero("masi", 6);

        heros.Create(hero);
        heros.Create(hero1);
        var heroToremoved = hero2;
        Assert.Throws<ArgumentNullException>(() => heros.Remove(name), $"Name cannot be null");
    }
    [Test]
    public void BoolRemoved()
    {
        HeroRepository heros = new HeroRepository();
        Hero hero = new Hero("lasi", 5);
        Hero hero1 = new Hero("basi", 6);
        Hero hero2 = new Hero("masi", 6);
        heros.Create(hero);
        heros.Create(hero1);
        heros.Create(hero2);
        heros.Remove("lasi");
        Assert.AreEqual(false, heros.Remove(hero.Name));
        var herotoremoved = heros.Remove("basi");
        bool isRemoved = heros.Remove("basi");

        Assert.AreEqual(isRemoved, heros.Remove("basi"));
        
    }
    [Test]
    public void GetHeroWithHighestLevel()
    {
        HeroRepository heros = new HeroRepository();
        Hero hero = new Hero("lasi", 5);
        Hero hero1 = new Hero("basi", 7);
        heros.Create(hero);
        heros.Create(hero1);
         var highhero=heros.GetHeroWithHighestLevel();
        Assert.AreEqual("basi",highhero.Name);
        Assert.AreEqual(7, highhero.Level);

    }
    [Test]
    public void GetHero()
    {
        HeroRepository heros = new HeroRepository();
        Hero hero = new Hero("lasi", 5);
        Hero hero1 = new Hero("basi", 7);
        heros.Create(hero);
        heros.Create(hero1);
        var gethero = heros.GetHero("lasi");
        Assert.AreEqual(hero, gethero);
    }

}
