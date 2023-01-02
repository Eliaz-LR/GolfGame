using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTab : MonoBehaviour
{
    public GameObject scoreText;

    private void Awake(){
        string score = "";
        for (int i = 0; i < GameManager.instance.score.Length; i++){
            score += GameManager.instance.score[i].ToString();
            if (i < GameManager.instance.score.Length - 1){
                score += " | ";
            }
        }
        scoreText.GetComponent<TextMeshProUGUI>().text = score;
    }
}
