using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGridManager : MonoBehaviour
{
    public bool[,] playerGrid;

    public int gridHealth = 10;

    [SerializeField] List<Transform> playerGridPositions;
    [SerializeField] List<Image> gridSprites;

    public List<int> laserPower;

    [SerializeField] int r0, r1, r2, c0, c1, c2;

    [SerializeField] GameStateManager gSM;

    
    // Start is called before the first frame update
    void Start()
    {

        playerGrid = new bool[3, 3];
        playerGrid[0, 0] = true;
        playerGrid[0, 2] = true;
        playerGrid[2, 0] = true;
        playerGrid[2, 2] = true;
        GridPositionUpdater();

    }

    // Update is called once per frame
    void Update()
    {
        if(gSM.gameState != GameState.ArrangingGrid)
        {
            
        }
    }

    public void GridTakeDamage(int num)
    {
        gridHealth -= num;
        if(gridHealth <= 0)
        {

        }
    }
    void GridPositionUpdater()
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                if(playerGrid[i, j])
                {
                    gridSprites[(i * 3) + j].color = Color.red;
                }
                else
                {
                    gridSprites[(i * 3) + j].color = Color.white;
                }
            }
        }

        LaserActivation();
    }

    void LaserActivation()
    {
        c0 = 0;
        c1 = 0;
        c2 = 0;
        r0 = 0;
        r1 = 0;
        r2 = 0;
        for(int i = 0; i < laserPower.Count; i++)
        {
            laserPower[i] = 0;
        }

        if(playerGrid[0, 0])
        {
            c0++;
            r0++;
        }
        if(playerGrid[0, 1])
        {
            r0++;
            c1++;
        }
        if(playerGrid[0, 2])
        {
            r0++;
            c2++;
        }
        if (playerGrid[1, 0])
        {
            r1++;
            c0++;
        }
        if (playerGrid[1, 1])
        {
            r1++;
            c1++;
        }
        if (playerGrid[1, 2])
        {
            r1++;
            c2++;
        }
        if (playerGrid[2, 0])
        {
            r2++;
            c0++;
        }
        if (playerGrid[2, 1])
        {
            r2++;
            c1++;
        }
        if (playerGrid[2, 2])
        {
            r2++;
            c2++;
        }

        laserPower[0] = c0;
        laserPower[1] = c1;
        laserPower[2] = c2;
        laserPower[3] = r0;
        laserPower[4] = r1;
        laserPower[5] = r2;
        laserPower[6] = c2;
        laserPower[7] = c1;
        laserPower[8] = c0;
        laserPower[9] = r2;
        laserPower[10] = r1;
        laserPower[11] = r0;

    }

    //move right
    public void TopMoveRight()
    {
        bool temp = playerGrid[0, 2];
        playerGrid[0, 2] = playerGrid[0, 1];
        playerGrid[0, 1] = playerGrid[0, 0];
        playerGrid[0, 0] = temp;

        GridPositionUpdater();
    }
    public void MidHorMoveRight()
    {
        bool temp = playerGrid[1, 2];
        playerGrid[1, 2] = playerGrid[1, 1];
        playerGrid[1, 1] = playerGrid[1, 0];
        playerGrid[1, 0] = temp;

        GridPositionUpdater();

    }
    public void BotMoveRight()
    {
        bool temp = playerGrid[2, 2];
        playerGrid[2, 2] = playerGrid[2, 1];
        playerGrid[2, 1] = playerGrid[2, 0];
        playerGrid[2, 0] = temp;

        GridPositionUpdater();

    }

    //move left
    public void TopMoveLeft()
    {
        bool temp = playerGrid[0, 0];
        playerGrid[0, 0] = playerGrid[0, 1];
        playerGrid[0, 1] = playerGrid[0, 2];
        playerGrid[0, 2] = temp;

        GridPositionUpdater();

    }
    public void MidHorMoveLeft()
    {
        bool temp = playerGrid[1, 0];
        playerGrid[1, 0] = playerGrid[1, 1];
        playerGrid[1, 1] = playerGrid[1, 2];
        playerGrid[1, 2] = temp;

        GridPositionUpdater();

    }
    public void BotMoveLeft()
    {
        bool temp = playerGrid[2, 0];
        playerGrid[2, 0] = playerGrid[2, 1];
        playerGrid[2, 1] = playerGrid[2, 2];
        playerGrid[2, 2] = temp;

        GridPositionUpdater();

    }

    //move up
    public void RightMoveUp()
    {
        bool temp = playerGrid[0, 2];
        playerGrid[0, 2] = playerGrid[1, 2];
        playerGrid[1, 2] = playerGrid[2, 2];
        playerGrid[2, 2] = temp;

        GridPositionUpdater();

    }
    public void MidVerMoveUp()
    {
        bool temp = playerGrid[0, 1];
        playerGrid[0, 1] = playerGrid[1, 1];
        playerGrid[1, 1] = playerGrid[2, 1];
        playerGrid[2, 1] = temp;

        GridPositionUpdater();

    }
    public void LeftMoveUp()
    {
        bool temp = playerGrid[0, 0];
        playerGrid[0, 0] = playerGrid[1, 0];
        playerGrid[1, 0] = playerGrid[2, 0];
        playerGrid[2, 0] = temp;

        GridPositionUpdater();


    }

    //move down
    public void RightMoveDown()
    {
        bool temp = playerGrid[2, 2];
        playerGrid[2, 2] = playerGrid[1, 2];
        playerGrid[1, 2] = playerGrid[0, 2];
        playerGrid[0, 2] = temp;

        GridPositionUpdater();


    }
    public void MidVerMoveDown()
    {
        bool temp = playerGrid[2, 1];
        playerGrid[2, 1] = playerGrid[1, 1];
        playerGrid[1, 1] = playerGrid[0, 1];
        playerGrid[0, 1] = temp;

        GridPositionUpdater();

    }
    public void LeftMoveDown()
    {
        bool temp = playerGrid[2, 0];
        playerGrid[2, 0] = playerGrid[1, 0];
        playerGrid[1, 0] = playerGrid[0, 0];
        playerGrid[0, 0] = temp;

        GridPositionUpdater();

    }
}
