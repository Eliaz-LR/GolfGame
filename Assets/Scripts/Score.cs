using System;
using UnityEngine;

[Serializable]
public class Score
{
    public int totalScore;
    public int[] score;
    public string pseudo;
    public string level;
    public Score(int[] score, string pseudo, string level)
    {
        this.totalScore = 0;
        for (int i = 0; i < score.Length; i++)
        {
            this.totalScore += score[i];
        }
        this.score = score;
        this.pseudo = pseudo;
        this.level = level;
    }
}