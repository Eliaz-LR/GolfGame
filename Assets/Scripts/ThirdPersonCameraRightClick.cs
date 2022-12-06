using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
 
public class ThirdPersonCameraRightClick : MonoBehaviour {

    [SerializeField] private DragAndShoot dragAndShoot;
    void Start(){
        CinemachineCore.GetInputAxis = GetAxisCustom; //Set the CinemachineCore GetInputAxis delegate to our custom method
    }
    public float GetAxisCustom(string axisName){
        if(axisName == "Mouse X"){
            if (Input.GetMouseButton(0) && !dragAndShoot.mouseOnBall){
                return UnityEngine.Input.GetAxis("Mouse X");
            } else{
                // return UnityEngine.Input.GetAxis(axisName);
                return 0;
            }
        }
        else if (axisName == "Mouse Y"){
            if (Input.GetMouseButton(0) && !dragAndShoot.mouseOnBall){
                return UnityEngine.Input.GetAxis("Mouse Y");
            } else{
                // return UnityEngine.Input.GetAxis(axisName);
                return 0;
            }
        }
        return UnityEngine.Input.GetAxis(axisName);
    }
}