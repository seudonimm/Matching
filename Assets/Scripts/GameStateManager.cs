using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Shapes;

public class GameStateManager : MonoBehaviour
{
    public GameState gameState;
    public int turns;

    [SerializeField] EnemyManager eM; //to access EnemyManager script
    [SerializeField] PlayerGridManager pGM; // to access 

    [SerializeField] List<Button> buttons;

    [SerializeField] float arrangingTime, arrangingTimeDefault, laserTime, laserRate;

    [SerializeField] TextMeshProUGUI turnTimerText; // display time left for turn

    [SerializeField] TextMeshProUGUI currentTurnText; // displays current number of turns passes

    [SerializeField] TextMeshProUGUI currentScoreText, highScoreText; //

    [SerializeField] Rectangle gridHitEffect;
    [SerializeField] GameObject enemyDeathEffect, enemyAttackEffect;

    [SerializeField] List<GameObject> lasers; 

    [SerializeField] bool damageDealt; //to tell if damage has been dealt for current turn

    [SerializeField] GameObject instructionsPanel, gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        arrangingTime = arrangingTimeDefault;
        currentTurnText.text = "Turn:\n" + turns.ToString();

        Values.CurrentScore = 0;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = Values.HiScore.ToString();

        GameStateMachine();
        GetInstructions();

        turnTimerText.text = "Time:\n" + arrangingTime.ToString();

        if(pGM.gridHealth <= 3)
        {
            pGM.gridHealthText.color = Color.red;
        }
        

        laserTime += Time.deltaTime * laserRate;

        //decreases time as score increases to increase difficulty over time
        if (Values.CurrentScore < 100)
        {
            arrangingTimeDefault = 10;
        }
        else if (Values.CurrentScore < 200)
        {
            arrangingTimeDefault = 9;
        }
        else if (Values.CurrentScore < 300)
        {
            arrangingTimeDefault = 8;
        }
        else if (Values.CurrentScore < 400)
        {
            arrangingTimeDefault = 7;
        }
        else if (Values.CurrentScore < 500)
        {
            arrangingTimeDefault = 6;
        }
        else if (Values.CurrentScore < 600)
        {
            arrangingTimeDefault = 5;
        }
        else if (Values.CurrentScore < 700)
        {
            arrangingTimeDefault = 4;
        }
        else if (Values.CurrentScore < 800)
        {
            arrangingTimeDefault = 3;
        }
        else if (Values.CurrentScore < 900)
        {
            arrangingTimeDefault = 2;
        }


    }

    
    void GameStateMachine()
    {
        switch (gameState)
        {

            case GameState.GameStart:
                instructionsPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    instructionsPanel.SetActive(false);
                    gameState = GameState.EnemySpawn;
                }
                break;
            
            
            case GameState.ArrangingGrid:
                arrangingTime -= Time.deltaTime;

                if (arrangingTime <= 0)
                {
                    //diables buttons when in other states
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        buttons[i].interactable = false;
                    }
                    gameState = GameState.LaserAttack;
                }
                laserTime = 0;

                break;

            case GameState.LaserAttack:
                //controls effect for laser firing
                for (int i = 0; i < lasers.Count; i++)
                {
                    if (lasers[i])
                    {
                        float t = Mathf.Lerp(20, 1, laserTime);

                        lasers[i].transform.localScale = new Vector2(1, t);

                    }
                }
                //let damage only happen once while laser effect finishes
                if (!damageDealt)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        //deal damage to enemies
                        if (eM.enemyLanes[i])
                        {
                            eM.enemiesInLane[i].TakeDamage(pGM.laserPower[i]);


                            //remove enemy from array when health is zero
                            if (eM.enemiesInLane[i].Health <= 0)
                            {
                                Instantiate(enemyDeathEffect, eM.enemyOnGrid[i].transform.position, eM.enemyOnGrid[i].transform.rotation);
                                eM.enemiesInLane[i] = null;
                                eM.enemyLanes[i] = false;
                            }
                        }
                        damageDealt = true;
                    }
                }
                currentScoreText.text = "Score:\n" + Values.CurrentScore.ToString();

                if (laserTime > 1)
                {
                    damageDealt = false;
                    gameState = GameState.EnemyMovement;
                }
                
                break;

            case GameState.EnemyMovement:

                for (int i = 0; i < 12; i++)
                {
                    if (eM.enemyLanes[i])
                    {
                        eM.enemiesInLane[i].EnemyMove();
                        if (eM.enemiesInLane[i].DistanceFromGrid <= 0)
                        {
                            //deals damage to player when enemy reaches grid
                            pGM.gridHealth -= eM.enemiesInLane[i].Health;
                            //creates effect for grid losing health
                            Instantiate(gridHitEffect, transform.position, transform.rotation);

                            Instantiate(enemyAttackEffect, eM.enemyOnGrid[i].transform.position, enemyAttackEffect.transform.rotation);

                            //remove enemy from array when it reaches grid
                            eM.enemiesInLane[i] = null;
                            eM.enemyLanes[i] = false;


                        }
                    }
                }
                turns++;
                currentTurnText.text = "Turn:\n" + turns.ToString();

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

                if (Values.CurrentScore > Values.HiScore)
                {
                    Values.HiScore = Values.CurrentScore;
                }
                gameState = GameState.Reset;
                break;

            case GameState.Reset:
                gameOverPanel.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    gameOverPanel.SetActive(false);
                    Values.CurrentScore = 0;
                    currentScoreText.text = Values.CurrentScore.ToString();
                    turns = 0;
                    currentTurnText.text = turns.ToString();
                    gameState = GameState.EnemySpawn;

                    arrangingTime = arrangingTimeDefault;

                    pGM.gridHealthText.color = Color.white;

                    for (int i = 0; i < 12; i++)
                    {
                        if (eM.enemyLanes[i])
                        {
                            eM.enemiesInLane[i] = null;
                            eM.enemyLanes[i] = false;

                        }
                    }

                }
                break;
        }
    }

    void GetInstructions()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!instructionsPanel.activeInHierarchy)
            {
                instructionsPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
        if ((instructionsPanel.activeInHierarchy && Input.GetKeyDown(KeyCode.Mouse0)) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            instructionsPanel.SetActive(false);
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //for use with the End Turn button in game
    public void EndTurn()
    {
        if(gameState == GameState.ArrangingGrid)
        {
            gameState = GameState.LaserAttack;
        }
    }

    

}

public enum GameState
{
    GameStart,
    ArrangingGrid,
    LaserAttack,
    EnemyMovement,
    EnemySpawn,
    LoseState,
    Reset
}
