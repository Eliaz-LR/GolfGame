using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finished : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>Methode qui est lancée quand la balle touche le drapeau final. Elle est accrochée à l'ecran de victoire ce qui lui permet de l'acceder + facilement et de ne pas surcharger OnFlagCollision().</summary>
    public void WhenFinished()
    {
        Time.timeScale = 0f; // Pause the game
        ScoreManager.instance.SaveScore(GameManager.instance.score);
    }
}
