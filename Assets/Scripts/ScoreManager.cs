using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

public class ScoreManager
{
    public static ScoreManager instance;

    private void Awake(){
        instance = this;
    }

    public void SaveScore(Score score)
    {

        Debug.Log("Total score: " + score.totalScore);

    }
    // private void PushToDatabase()
    // {
    //     RestClient.Put("https://demineur-3d-default-rtdb.europe-west1.firebasedatabase.app/"+DifficultyGrid.difficulty+"/"+pseudoField.text+".json",score);
    // }
    // private void CompareWithDatabase(Score score)
    // {
    //     RestClient.Get<Score>("https://demineur-3d-default-rtdb.europe-west1.firebasedatabase.app/"+DifficultyGrid.difficulty+"/"+pseudoField.text+".json").Then(response =>
    //     {
    //         if (score.time<response.time)
    //         {
    //             Debug.Log("score pushed");
    //             PushToDatabase(score);
    //         }
    //         return;
    //     }).Catch(err=>{
    //         Debug.Log("score pushed err");
    //         PushToDatabase(score);
    //     });
    // }
}
