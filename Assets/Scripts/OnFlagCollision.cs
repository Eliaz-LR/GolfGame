using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFlagCollision : MonoBehaviour
{
    private GameObject golfball;
    private GameObject FinishedScreen;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        golfball = GameObject.Find("Golfball");
        FinishedScreen = GameObject.Find("Finished Screen");
    }

    private bool isLastHole()
    {
        return gameManager.hole == GameManager.par.Length - 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == golfball.name)
        {
            Debug.Log("Golfball finished !"); // TODO: Add a flag animation
            gameManager.resetStrike();
            if (isLastHole())
            {
                Debug.Log("Game finished !");
                Finished();
            }
            else
            {
                gameManager.hole++;
                golfball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                golfball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                golfball.transform.rotation = Quaternion.identity;
                golfball.transform.position = gameManager.ballPos[gameManager.hole];
            }

        }
    }

    private void Finished()
    {
        FinishedScreen.SetActive(true);
        Time.timeScale = 0f; // Pause the game
        ScoreManager.instance.SaveScore(gameManager.score);
    }

}
