using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    
    public void changeSkin(Mesh mesh){
        StateNameController.skin = mesh;
    }

    public void defaultSkin(Mesh mesh){
        if(StateNameController.skin == null){
            StateNameController.skin = mesh;
        }
    }

    public void PlayLevel(int level)
    {  
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Le jeu s'est arrêté");
        Application.Quit();
    }
    
}
