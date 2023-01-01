using UnityEngine;
using Proyecto26;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private void Awake(){
        instance = this;
        Debug.Log("ScoreManager Awake");
    }

    public void SaveScore(Score score, string pseudo, string level)
    {
        Debug.Log(pseudo+" "+level+" "+score.totalScore);
        CompareWithDatabase(score, pseudo, level);
    }
    private void PushToDatabase(Score score, string pseudo, string level)
    {
        RestClient.Put("https://golfgame-8ff30-default-rtdb.europe-west1.firebasedatabase.app/score/"+level+"/"+pseudo+".json", score)
        .Then(response =>
        {
            Debug.Log("score pushed");
        })
        .Catch(err=>{Debug.Log("score push err"+err.Message);});
    }

    private void CompareWithDatabase(Score score, string pseudo, string level)
    {
        RestClient.Get<Score>("https://golfgame-8ff30-default-rtdb.europe-west1.firebasedatabase.app/score/"+level+"/"+pseudo+".json").Then(response =>
        {
            if (score.totalScore<response.totalScore) // if the score is better (aka lower) than the one in the database we push it
            {
                PushToDatabase(score, pseudo, level);
            }
            return;
        }).Catch(err=>{
            Debug.Log("Score not compared : "+err.Message);
            PushToDatabase(score, pseudo, level);
        });
    }
}
