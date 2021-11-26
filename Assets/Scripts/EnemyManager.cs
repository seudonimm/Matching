using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //keeps track of what lanes have an enemy
    public List<bool> enemyLanes;

    //the enemy objects in their respective lanes
    public List<Enemy1> enemiesInLane;

    [SerializeField] GameStateManager gSM;

    // Start is called before the first frame update
    void Start()
    {
        enemiesInLane = new List<Enemy1>(new Enemy1[12]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemySpawn()
    {
        int rand = Random.Range(0, 12);

        if (!enemyLanes[rand])
        {
            enemyLanes[rand] = true;
            enemiesInLane[rand] = new Enemy1(Random.Range(1, 6), Random.Range(2, 5));
        }
    }
}
