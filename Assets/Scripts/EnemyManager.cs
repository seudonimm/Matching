using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    //keeps track of what lanes have an enemy
    public List<bool> enemyLanes;
    [SerializeField] List<GameObject> enemyOnGrid;

    //the enemy objects in their respective lanes
    public List<Enemy1> enemiesInLane;

    [SerializeField] List<TextMeshProUGUI> enemyHealth;
    [SerializeField] List<TextMeshProUGUI> enemyDistance;

    [SerializeField] GameStateManager gSM;

    // Start is called before the first frame update
    void Start()
    {
        enemiesInLane = new List<Enemy1>(new Enemy1[12]);
    }

    // Update is called once per frame
    void Update()
    {
        PlaceEnemyOnScreen();
        DisplayEnemyValues();
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

    void PlaceEnemyOnScreen()
    {
        for(int i = 0; i < 12; i++)
        {
            if(enemyLanes[i] && !enemyOnGrid[i].activeSelf)
            {
                enemyOnGrid[i].SetActive(true);
            }

            if (!enemyLanes[i] && enemyOnGrid[i].activeSelf)
            {
                enemyOnGrid[i].SetActive(false);
            }
        }
    }

    void DisplayEnemyValues()
    {
        for (int i = 0; i < 12; i++)
        {
            if (enemyLanes[i])
            {
                enemyHealth[i].text = enemiesInLane[i].Health.ToString();
                enemyDistance[i].text = enemiesInLane[i].DistanceFromGrid.ToString();
                //enemyOnGrid[i].SetActive(true);
            }

            if (!enemyLanes[i])
            {
                enemyHealth[i].text = "";
                enemyDistance[i].text = "";

                //enemyOnGrid[i].SetActive(false);
            }
        }

    }
}
