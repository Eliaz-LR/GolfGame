using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] private GameObject golfball;
    private Vector3 lastPos;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == golfball.name)
        {
            Debug.Log("Golfball hit the out of bounds");
            lastPos = golfball.GetComponent<DragAndShoot>().lastPos;
            golfball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            golfball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            golfball.transform.position = lastPos;
            golfball.transform.rotation = Quaternion.identity;
        }
    }
}
