using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGridManager : MonoBehaviour
{
    public bool[,] playerGrid;

    [SerializeField] List<Vector2> playerGridPositions;
    [SerializeField] Button buttonRightTop, ButtonRightMid, ButtonLeftBot;
    // Start is called before the first frame update
    void Start()
    {
        playerGrid = new bool[3, 3];
        playerGrid[0, 0] = true;
        playerGrid[0, 2] = true;
        playerGrid[2, 0] = true;
        playerGrid[2, 2] = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //move right
    public void TopMoveRight()
    {
        bool temp = playerGrid[0, 2];
        playerGrid[0, 2] = playerGrid[0, 1];
        playerGrid[0, 1] = playerGrid[0, 0];
        playerGrid[0, 0] = temp;
    }
    public void MidHorMoveRight()
    {
        bool temp = playerGrid[1, 2];
        playerGrid[1, 2] = playerGrid[1, 1];
        playerGrid[1, 1] = playerGrid[1, 0];
        playerGrid[1, 0] = temp;

    }
    public void BotMoveRight()
    {
        bool temp = playerGrid[2, 2];
        playerGrid[2, 2] = playerGrid[2, 1];
        playerGrid[2, 1] = playerGrid[2, 0];
        playerGrid[2, 0] = temp;

    }

    //move left
    public void TopMoveLeft()
    {
        bool temp = playerGrid[0, 0];
        playerGrid[0, 1] = playerGrid[0, 2];
        playerGrid[0, 0] = playerGrid[0, 1];
        playerGrid[0, 2] = temp;

    }
    public void MidHorMoveLeft()
    {
        bool temp = playerGrid[1, 0];
        playerGrid[1, 1] = playerGrid[1, 2];
        playerGrid[1, 0] = playerGrid[1, 1];
        playerGrid[1, 2] = temp;

    }
    public void BotMoveLeft()
    {
        bool temp = playerGrid[2, 0];
        playerGrid[2, 1] = playerGrid[2, 2];
        playerGrid[2, 0] = playerGrid[2, 1];
        playerGrid[2, 2] = temp;

    }

    //move up
    public void RightMoveUp()
    {
        bool temp = playerGrid[0, 0];
        playerGrid[0, 0] = playerGrid[1, 0];
        playerGrid[1, 0] = playerGrid[2, 0];
        playerGrid[2, 0] = temp;

    }
    public void MidVerMoveUp()
    {
        bool temp = playerGrid[0, 1];
        playerGrid[0, 1] = playerGrid[1, 1];
        playerGrid[1, 1] = playerGrid[2, 1];
        playerGrid[2, 1] = temp;

    }
    public void LeftMoveUp()
    {
        bool temp = playerGrid[0, 2];
        playerGrid[0, 2] = playerGrid[1, 2];
        playerGrid[1, 2] = playerGrid[2, 2];
        playerGrid[2, 2] = temp;

    }

    //move down
    public void RightMoveDown()
    {
        bool temp = playerGrid[2, 0];
        playerGrid[2, 0] = playerGrid[1, 0];
        playerGrid[1, 0] = playerGrid[0, 0];
        playerGrid[0, 0] = temp;

    }
    public void MidVerMoveDown()
    {
        bool temp = playerGrid[2, 1];
        playerGrid[2, 1] = playerGrid[1, 1];
        playerGrid[1, 1] = playerGrid[0, 1];
        playerGrid[0, 1] = temp;

    }
    public void LeftMoveDown()
    {
        bool temp = playerGrid[2, 2];
        playerGrid[2, 2] = playerGrid[1, 2];
        playerGrid[1, 2] = playerGrid[0, 2];
        playerGrid[0, 2] = temp;

    }
}
