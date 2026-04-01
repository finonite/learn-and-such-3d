using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Karakter
{
    public string Nama { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }

    public Karakter(string nama, int health, int damage)
    {
        Nama = nama;
        Health = health;
        Damage = damage;
    }

    public abstract void Attack();
}

public class Warrior : Karakter
{
    public Warrior(string nama) : base(nama, 100, 20) { }

    public override void Attack()
    {
        Console.WriteLine($"{Nama} menebas musuh dengan pedang! (Damage: {Damage})");
    }
}

public class Mage : Karakter
{
    public Mage(string nama) : base(nama, 70, 35) { }

    public override void Attack()
    {
        Console.WriteLine($"{Nama} melontarkan bola api sihir! (Damage: {Damage})");
    }
}

public class Archer : Karakter
{
    public Archer(string nama) : base(nama, 80, 25) { }

    public override void Attack()
    {
        Console.WriteLine($"{Nama} menembak panah dari jarak jauh! (Damage: {Damage})");
    }
}

class Program
{
    static void Main()
    {
        Karakter hero1 = new Warrior("Aragon");
        Karakter hero2 = new Mage("Gandalf");
        Karakter hero3 = new Archer("Legolas");

        hero1.Attack();
        hero2.Attack();
        hero3.Attack();
    }
}