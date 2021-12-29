using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Values
{
    private static float currentScore;
    private static float hiScore;

    public static float CurrentScore { get => currentScore; set => currentScore = value; }
    public static float HiScore { get => hiScore; set => hiScore = value; }
}
