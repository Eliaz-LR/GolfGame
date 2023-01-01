using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private void Awake(){
        instance = this;
    }

    public void SaveScore(Score score)
    {
        Debug.Log(score.pseudo+" "+score.level+" "+score.totalScore);
        CompareWithDatabase(score);
    }
    private void PushToDatabase(Score score)
    {
        RestClient.Put("https://golfgame-8ff30-default-rtdb.europe-west1.firebasedatabase.app/score/"+score.level+"/"+score.pseudo+".json", score)
        .Then(response =>
        {
            Debug.Log("score pushed");
        })
        .Catch(err=>{Debug.Log("score push err"+err.Message);});
    }

    private void CompareWithDatabase(Score score)
    {
        RestClient.Get<Score>("https://golfgame-8ff30-default-rtdb.europe-west1.firebasedatabase.app/score/"+score.level+"/"+score.pseudo+".json").Then(response =>
        {
            if (score.totalScore<response.totalScore) // if the score is better (aka lower) than the one in the database we push it
            {
                PushToDatabase(score);
            }
            return;
        }).Catch(err=>{
            Debug.Log("Score not compared : "+err.Message);
            PushToDatabase(score);
        });
    }

}
