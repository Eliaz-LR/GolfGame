using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject strikes;

    public static int[] par = new int[] {2,3};
    public Vector3[] ballPos;
    public int[] score = new int[par.Length];
    public int hole = 0;

    private int nbStrikes = 0; 

    private void Awake(){
        instance = this;
    }

    private void Start(){
        strikes.GetComponent<TextMeshProUGUI>().text = nbStrikes.ToString();
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
