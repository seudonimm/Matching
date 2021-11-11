using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGridManager : MonoBehaviour
{
    public bool[,] playerGrid;

    [SerializeField] List<Transform> playerGridPositions;
    [SerializeField] List<Image> gridSprites;

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

        //if (playerGrid[0, 0])
        //{
        //    gridSprites[0].color = Color.red;
        //}
        //else
        //{
        //    gridSprites[0].color = Color.white;
        //}

        //if (playerGrid[0, 1])
        //{
        //    gridSprites[1].color = Color.red;
        //}
        //else
        //{
        //    gridSprites[1].color = Color.white;
        //}

        //if (playerGrid[0, 2])
        //{
        //    gridSprites[2].color = Color.red;
        //}
        //else
        //{
        //    gridSprites[2].color = Color.white;
        //}

        //if (playerGrid[1, 0])
        //{
        //    gridSprites[3].color = Color.red;
        //}
        //else
        //{
        //    gridSprites[3].color = Color.white;
        //}

        //if (playerGrid[1, 1])
        //{
        //    gridSprites[4].color = Color.red;
        //}
        //else
        //{
        //    gridSprites[4].color = Color.white;
        //}

        //if (playerGrid[1, 2])
        //{
        //    gridSprites[5].color = Color.red;
        //}
        //else
        //{
        //    gridSprites[5].color = Color.white;
        //}

        //if (playerGrid[2, 0])
        //{
        //    gridSprites[6].color = Color.red;
        //}
        //else
        //{
        //    gridSprites[6].color = Color.white;
        //}

        //if (playerGrid[2, 1])
        //{
        //    gridSprites[7].color = Color.red;
        //}
        //else
        //{
        //    gridSprites[7].color = Color.white;
        //}

        //if (playerGrid[2, 2])
        //{
        //    gridSprites[8].color = Color.red;
        //}
        //else
        //{
        //    gridSprites[8].color = Color.white;
        //}

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
        bool temp = playerGrid[0, 0];
        playerGrid[0, 0] = playerGrid[1, 0];
        playerGrid[1, 0] = playerGrid[2, 0];
        playerGrid[2, 0] = temp;

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
        bool temp = playerGrid[0, 2];
        playerGrid[0, 2] = playerGrid[1, 2];
        playerGrid[1, 2] = playerGrid[2, 2];
        playerGrid[2, 2] = temp;

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
