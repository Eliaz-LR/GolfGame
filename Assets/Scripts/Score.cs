using System;

[Serializable]
public class Score
{
    public int totalScore; //time in seconds
    public string pseudo;
    public string level;
    public Score(int[] score, string pseudo, string level)
    {
        this.totalScore = 0;
        for (int i = 0; i < score.Length; i++)
        {
            this.totalScore += score[i];
        }
        this.pseudo = pseudo;
        this.level = level;
    }
}