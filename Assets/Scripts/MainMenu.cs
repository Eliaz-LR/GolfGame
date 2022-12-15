using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    
    public GameObject LevelNumber;

    public void PlayLevel(int level){

        //levelNumber = LevelNumber.GetComponent<TextMeshProUGUI>().text;
        //Debug.Log(levelNumber);
        SceneManager.LoadScene(level);
    }

    public void QuitGame(){
        Debug.Log("Le jeu s'est arrêté");
        Application.Quit();
    }
    
}
