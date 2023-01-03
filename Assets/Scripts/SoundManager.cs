using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;
   public void ChangeMasterVolume(float value){
        AudioListener.volume = value;
   }
}
