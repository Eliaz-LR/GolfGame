using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Finished : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private TMP_InputField pseudoField;

    /// <summary>Methode qui est lancée quand la balle touche le drapeau final. Elle est accrochée à l'ecran de victoire ce qui lui permet de l'acceder + facilement et de ne pas surcharger OnFlagCollision().</summary>
    public void WhenFinished()
    {
        Time.timeScale = 0f; // Pause the game
        menuButton.onClick.AddListener(ReturnToMenu);
        pseudoField.onSubmit.AddListener(ReturnToMenuCopy);
    }

    private void ReturnToMenu()
    {
        if (pseudoField.text!="")
        {
            SaveScore();
        }
        GameManager.instance.ReturnToMenu();
    }
    private void ReturnToMenuCopy(string osef)
    {
        ReturnToMenu();
    }

    private void SaveScore()
    {
        Score score = new Score(GameManager.instance.score);
        ScoreManager.instance.SaveScore(score, pseudoField.text, "Level_Grass");
    }
}
