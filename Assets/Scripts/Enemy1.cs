using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 
{
    private int health;
    private int distanceFromGrid;

    bool dead, attacked;

    public int Health { get => health; set => health = value; }
    public int DistanceFromGrid { get => distanceFromGrid; set => distanceFromGrid = value; }

    public Enemy1(int health, int distanceFromGrid)
    {
        this.health = health;
        this.distanceFromGrid = distanceFromGrid;
    }

    public void TakeDamage(int num)
    {
        health -= num;

        if(health <= 0)
        {
            dead = true;
        }
    }

    public void EnemyMove()
    {
        distanceFromGrid--;

        if(distanceFromGrid <= 0)
        {
            attacked = true;
        }
    }
}
