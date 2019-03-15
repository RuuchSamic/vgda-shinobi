using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour

{
    public static CameraController instance;
    private void OnEnable()
    {
        if (instance == null)
            instance = this;

        mainCamera = GetComponent<Camera>();
    }

    private void OnDisable()
    {
        instance = null;
    }

    public Camera mainCamera;
}
