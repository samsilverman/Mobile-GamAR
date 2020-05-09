using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraController : MonoBehaviour
{
    public Camera overlayCamera; 
    public float height = 2.0f;

    void Start()
    {
        SetProjectionMatrixAndFOV();
    }

    void Update()
    {
        Vector3 pos = Camera.main.transform.position;
        pos.y = height;
        overlayCamera.transform.position = pos;

        Vector3 rot = overlayCamera.transform.rotation.eulerAngles;
        rot.y = Camera.main.transform.rotation.eulerAngles.y;
        overlayCamera.transform.eulerAngles = rot;


    }


    private void SetProjectionMatrixAndFOV()
    {
        overlayCamera.fieldOfView = Camera.main.fieldOfView;
        overlayCamera.projectionMatrix = Camera.main.projectionMatrix;
    }
}
