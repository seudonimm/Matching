using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    public GameState gameState;
    public int turns;

    [SerializeField] EnemyManager eM;
    [SerializeField] PlayerGridManager pGM;

    [SerializeField] List<Button> buttons;

    [SerializeField] float arrangingTime, arrangingTimeDefault;

    [SerializeField] TextMeshProUGUI turnTimerText;

    [SerializeField] TextMeshProUGUI currentTurnText;

    // Start is called before the first frame update
    void Start()
    {
        arrangingTime = arrangingTimeDefault;
        currentTurnText.text = turns.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        GameStateMachine();

        turnTimerText.text = arrangingTime.ToString();
    }

    void GameStateMachine()
    {
        switch (gameState)
        {
            case GameState.ArrangingGrid:
                arrangingTime -= Time.deltaTime;

                if(arrangingTime <= 0)
                {
                    for(int i = 0; i < buttons.Count; i++)
                    {
                        buttons[i].interactable = false;
                    }
                    gameState = GameState.LaserAttack;
                }

                break;

            case GameState.LaserAttack:

                for (int i = 0; i < 12; i++)
                {
                    //deal damage to enemies
                    if (eM.enemyLanes[i])
                    {
                        eM.enemiesInLane[i].TakeDamage(pGM.laserPower[i]);


                        //remove enemy from array when health is zero
                        if (eM.enemiesInLane[i].Health <= 0)
                        {
                            eM.enemiesInLane[i] = null;
                            eM.enemyLanes[i] = false;
                        }
                    }
                }

                gameState = GameState.EnemyMovement;

                break;

            case GameState.EnemyMovement:

                for(int i = 0; i < 12; i++)
                {
                    if (eM.enemyLanes[i])
                    {
                        eM.enemiesInLane[i].EnemyMove();
                        if (eM.enemiesInLane[i].DistanceFromGrid <= 0)
                        {
                            pGM.gridHealth -= eM.enemiesInLane[i].Health;

                            //remove enemy from array when it reaches grid
                            eM.enemiesInLane[i] = null;
                            eM.enemyLanes[i] = false;


                        }
                    }
                }
                turns++;
                currentTurnText.text = turns.ToString();

                if (pGM.gridHealth <= 0)
                {

                    gameState = GameState.LoseState;
                }
                else
                {

                    gameState = GameState.EnemySpawn;
                }
                
                break;

            case GameState.EnemySpawn:


                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].interactable = true;
                }

                arrangingTime = arrangingTimeDefault;
                eM.EnemySpawn();

                gameState = GameState.ArrangingGrid;

                break;

            case GameState.LoseState:


                break;
        }
    }
}

public enum GameState
{
    ArrangingGrid,
    LaserAttack,
    EnemyMovement,
    EnemySpawn,
    LoseState
}
