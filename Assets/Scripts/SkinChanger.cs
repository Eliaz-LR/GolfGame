using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    public GameObject ballMesh;

    private void Start(){

        if(StateNameController.skin != null){
            ballMesh.GetComponent<MeshFilter>().mesh = StateNameController.skin;
        }
    }
}
