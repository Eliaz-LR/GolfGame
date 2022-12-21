using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject strikes;

    public static int[] par = new int[] {2,2,4,3,5};
    public Vector3[] ballPos;
    public int[] score;
    public int hole = 0;

    private int nbStrikes = 0; 

    private void Awake(){
        instance = this;
    }

    private void Start(){
        strikes.GetComponent<TextMeshProUGUI>().text = nbStrikes.ToString();
        ballPos = new Vector3[]{
            new Vector3(0,1f,-0.5f),
            new Vector3(-25f,1f,3.5f),
            new Vector3(-42f,1f,3.5f),
            new Vector3(23.26f,1f,-5.67f),
            new Vector3(-65f,1f,3.5f),
        };
        score = new int[par.Length];
    }

    public void addStrike(){
        nbStrikes++;
        score[hole] = nbStrikes;
        strikes.GetComponent<TextMeshProUGUI>().text = nbStrikes.ToString();
    }
    public void resetStrike(){
        nbStrikes = 0;
        score[hole] = nbStrikes;
        strikes.GetComponent<TextMeshProUGUI>().text = nbStrikes.ToString();
    }
}
