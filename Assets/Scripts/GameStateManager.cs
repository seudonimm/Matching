using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public GameState gameState;
    public int turns;

    [SerializeField] EnemyManager eM;
    [SerializeField] PlayerGridManager pGM;

    [SerializeField] List<Button> buttons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameStateMachine()
    {
        switch (gameState)
        {
            case GameState.ArrangingGrid:
                

                break;

            case GameState.LaserAttack:

                turns++;
                for (int i = 0; i < 12; i++)
                {
                    eM.enemiesInLane[i].TakeDamage(pGM.laserPower[i]);
                }
                break;

            case GameState.EnemyMovement:

                for(int i = 0; i < 12; i++)
                {
                    eM.enemiesInLane[i].EnemyMove();
                    if(eM.enemiesInLane[i].DistanceFromGrid <= 0)
                    {
                        pGM.gridHealth -= eM.enemiesInLane[i].Health;
                    }
                }

                break;
        }
    }
}

public enum GameState
{
    ArrangingGrid,
    LaserAttack,
    EnemyMovement,
    EnemySpawn
}
