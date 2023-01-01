using System;
using UnityEngine;

[Serializable]
public class Score
{
    public int totalScore;
    public Score(int[] score)
    {
        this.totalScore = 0;
        for (int i = 0; i < score.Length; i++)
        {
            this.totalScore += score[i];
        }
    }
}