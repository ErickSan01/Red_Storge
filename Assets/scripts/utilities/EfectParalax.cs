using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla el efecto de paralaje en un objeto en relación con la cámara principal.
/// </summary>
public class EfectParalax : MonoBehaviour
{
    [SerializeField] private float ParallaxMultiplier;

    private Transform cameraTransform;
    private Vector3 previousCameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float deltaX = (cameraTransform.position.x - previousCameraPosition.x) * ParallaxMultiplier;
        transform.Translate(new Vector3(deltaX,0,0));
        previousCameraPosition = cameraTransform.position;
    }
}
