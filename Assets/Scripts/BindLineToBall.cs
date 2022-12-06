using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindLineToBall : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ball.transform.position;
    }
}
