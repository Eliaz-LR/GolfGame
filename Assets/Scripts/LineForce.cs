using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineForce : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer; //Ici SerializeField permet d'ajouter depuis l'editeur un linerenderer en le gardant privé (alternative : le mettre public)

    private void DrawLine(Vector3 direction) {
        Vector3[] positions = {
            transform.position,
            direction
        };
        lineRenderer.SetPositions(positions);
        lineRenderer.enabled = true;
    }
}
