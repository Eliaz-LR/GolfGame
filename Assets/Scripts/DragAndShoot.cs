using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody rb;
    public LineRenderer lineRenderer; 

    private Camera mainCamera;
    private Vector3 startPos= Vector3.zero;
    private Vector3 endPos= Vector3.zero;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit)) //if ray hits something
            {
                if (hit.collider.gameObject.name == "Ball")
                {
                startPos = hit.point;
                Debug.Log("Start Pos: " + startPos);   
                }
            }
        }
        if (Input.GetMouseButton(0) && startPos != Vector3.zero)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                endPos = hit.point;
            }
            // Debug.Log("End Pos: " + endPos);

            DrawLine(startPos - endPos);
        }
        if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled = false;
            startPos = Vector3.zero;
            endPos = Vector3.zero;
        }
    }

    private void DrawLine(Vector3 direction) {
        Vector3[] positions = {
            transform.position,
            direction
        };
        lineRenderer.SetPositions(positions);
        lineRenderer.enabled = true;
    }
}
