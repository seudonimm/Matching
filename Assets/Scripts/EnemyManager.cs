using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] List<bool> enemyLanes;
    public List<Enemy1> enemiesInLane;

    [SerializeField] GameStateManager gSM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemySpawn()
    {
        int rand = Random.Range(0, 12);

        enemyLanes[rand] = true;
        enemiesInLane[rand] = new Enemy1(Random.Range(1, 6), Random.Range(2, 5));
    }
}
