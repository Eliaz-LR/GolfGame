using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody rb;
    public LineRenderer lineRenderer; 
    public bool mouseOnBall=false;

    private Camera mainCamera;
    private Vector3 startPos= Vector3.zero;
    private Vector3 endPos= Vector3.zero;
    private Vector3 direction = Vector3.zero;

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
                    mouseOnBall=true;
                    startPos = transform.position;
                }
            }
        }
        if (Input.GetMouseButton(0) && startPos != Vector3.zero)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                startPos = transform.position;
                endPos = hit.point;
                direction = startPos - endPos;
                direction.y = 0;
                if (direction.magnitude > 10)
                {
                    direction = direction.normalized*10;
                }
            }
            // Debug.Log("End Pos: " + endPos);

            DrawLine(direction);
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (direction.magnitude > 0.5)
            {
                Shoot(direction);
            }
            mouseOnBall=false;
            lineRenderer.enabled = false;
            startPos = endPos = direction = Vector3.zero;
        }
    }

    private void DrawLine(Vector3 direction) {
        Vector3[] positions = {
            transform.position - direction,
            transform.position
        };
        lineRenderer.SetPositions(positions);
        lineRenderer.enabled = true;
    }

    private void Shoot(Vector3 direction) {
        rb.AddForce(direction * power, ForceMode.Impulse);
    }
}
