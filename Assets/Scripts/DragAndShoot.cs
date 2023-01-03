using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    [SerializeField] private float power = 10f;
    [SerializeField] private float maxMagnitude = 10f;
    [SerializeField] private float minMagnitude = 0.5f;
    [SerializeField] private float speedCamera = 5f;
    [SerializeField] private float deadZone = 10f;

    public Rigidbody rb;
    public LineRenderer lineRenderer; 
    public Collider planeCollider;
    public bool mouseOnBall=false;
    public Vector3 lastPos;

    private Camera mainCamera;
    private Vector3 startPos= Vector3.zero;
    private Vector3 endPos= Vector3.zero;
    private Vector3 direction = Vector3.zero;

    // freelook camera
    [SerializeField] GameObject freeLookCamera;
    private Cinemachine.CinemachineFreeLook freeLookComponent;

    public AudioSource audioShoot;

    private void Start()
    {
        mainCamera = Camera.main;
        freeLookComponent = freeLookCamera.GetComponent<Cinemachine.CinemachineFreeLook>();
        audioShoot = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit)) //if ray hits something
            {
                if (hit.collider.gameObject.name == "Golfball")
                {
                    mouseOnBall=true;
                    startPos = transform.position;
                }
            }
        }
        if (Input.GetMouseButton(0) && startPos != Vector3.zero)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (planeCollider.Raycast(ray, out RaycastHit hit,100f))
            {
                startPos = transform.position;
                endPos = hit.point;
                direction = startPos - endPos;
                direction.y = 0;
                if (direction.magnitude > maxMagnitude)
                {
                    direction = direction.normalized*maxMagnitude;
                }
            }
            // Debug.Log("End Pos: " + endPos);

            if (direction.magnitude > minMagnitude)
            {
                DrawLine(direction);
                SetCameraAngle(direction);
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            if (direction.magnitude > minMagnitude)
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

    private void SetCameraAngle(Vector3 direction) {
        Quaternion rotationCamera = mainCamera.transform.rotation;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        float angle = AngleDifference(rotationCamera.eulerAngles.y, rotation.eulerAngles.y);
        if (!(angle < deadZone && angle > -deadZone))
        {
            freeLookComponent.m_XAxis.Value = (angle*speedCamera)/360f;
        }
    }

    float AngleDifference( float angle1, float angle2 )
    {
        float diff = ( angle2 - angle1 + 180 ) % 360 - 180;
        return diff < -180 ? diff + 360 : diff;
    }

    private void Shoot(Vector3 direction) {
        audioShoot.Play();
        lastPos = transform.position;
        rb.AddForce(direction * power, ForceMode.Impulse);
        GameManager.instance.addStrike();
    }

}
