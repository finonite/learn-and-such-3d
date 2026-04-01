using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void Attack();
    void TakeDamage(int amount);
}

public class Zombie : IEnemy
{
    private int hp = 50;
    private int rangeToAttack = 5;

    public void Attack()
    {
        if(player.position < rangeToAttack)
        {
        Console.WriteLine("Zombie menerjang dan menggigit dari jarak dekat!");
        }
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        Console.WriteLine($"Zombie terkena {amount} damage. Sisa HP: {hp}");
    }
}

public class Turret : IEnemy
{
    private int hp = 100;

    public void Attack()
    {
        Console.WriteLine("Turret mengunci target dan menembak dari kejauhan!");
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        Console.WriteLine($"Turret terkena {amount} damage (Armor mengurangi efek). Sisa HP: {hp}");
    }
}

public class Boss : IEnemy
{
    private int hp = 500;
    private int ultimateRequirement = 10;
    private int ultimateCharge = 0;

    public void Attack()
    {
        if(ultimateCharge == ultimateRequirement) {
        Console.WriteLine("BOSS MENGELUARKAN SERANGAN ULTIMATE: METEOR STRIKE!");
        ultimateCharge = 0;
        } else
        {
            ultimateCharge++;
        }
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        Console.WriteLine($"Boss menerima damage! Sisa HP: {hp}");
    }
}

class Program
{
    static void Main()
    {
        IEnemy[] enemies = { new Zombie(), new Turret(), new Boss() };

        foreach (var enemy in enemies)
        {
            enemy.Attack();
            enemy.TakeDamage(20);
            Console.WriteLine("-------------------");
        }
    }
}