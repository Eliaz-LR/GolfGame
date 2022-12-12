using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFlagCollision : MonoBehaviour
{
    [SerializeField] private GameObject golfball;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;   
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == golfball.name)
        {
            Debug.Log("Golfball finished !");
            gameManager.resetStrike();
            gameManager.hole++;
            golfball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            golfball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            golfball.transform.rotation = Quaternion.identity;
            Debug.Log(gameManager.ballPos[0]);
            golfball.transform.position = gameManager.ballPos[gameManager.hole];
        }
    }
}
