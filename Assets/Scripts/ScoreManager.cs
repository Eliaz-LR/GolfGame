using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    public static ScoreManager instance;

    private void Awake(){
        instance = this;
    }

    public void SaveScore(int[] score)
    {
        int totalScore = 0;
        for (int i = 0; i < score.Length; i++)
        {
            totalScore += score[i];
        }
        Debug.Log("Total score: " + totalScore);
    }
}
