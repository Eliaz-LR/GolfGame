using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject strikes;

    private int nbStrikes = 0; 

    private void Awake(){
        instance = this;
    }

    private void Start(){
        strikes.GetComponent<TextMeshProUGUI>().text = nbStrikes.ToString();
    }

    public void addStrike(){
        nbStrikes++;
        strikes.GetComponent<TextMeshProUGUI>().text = nbStrikes.ToString();
    }
}
