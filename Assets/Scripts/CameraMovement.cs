using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform lookAtTransform;

    public float zoomSpeed = 10f;
    public float rotationSpeed = 45f;

    public float minZoom = 0.5f;
    public float maxZoom = 15f;

    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        Zoom();
        Rotate();
    }

    private void Zoom()
    {
        float cameraDist = Vector3.Distance(cameraTransform.position, lookAtTransform.position);

        if(Input.GetKey(KeyCode.Q) && cameraDist < maxZoom)
        {
            cameraTransform.position -= cameraTransform.forward * zoomSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E) && cameraDist > minZoom)
        {
            cameraTransform.position += cameraTransform.forward * zoomSpeed * Time.deltaTime;
        }
    }

    private void Rotate()
    {
        cameraTransform.LookAt(lookAtTransform);

        if (Input.GetKey(KeyCode.W))
        {
            cameraTransform.position += cameraTransform.up * zoomSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            cameraTransform.position -= cameraTransform.right * zoomSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            cameraTransform.position -= cameraTransform.up * zoomSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            cameraTransform.position += cameraTransform.right * zoomSpeed * Time.deltaTime;
        }       
    }
}
