using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    [Header("Camera Option")]
    [SerializeField] private CameraSetting[] cameraSettings;
    [SerializeField] private float sensitivity = 10f;

    [Header("InputManager")]
    [SerializeField] private InputManager inputManager;
    private int currentCamera;
    private float mouseX;
    private float mouseY;
    private float rotY = 0f;
    private float rotX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentCamera = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDir = inputManager.GetLookInput();

        rotX += lookDir.x * sensitivity * Time.deltaTime;
        rotY -= lookDir.y * sensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, cameraSettings[currentCamera].minX, cameraSettings[currentCamera].maxX);
        rotY = Mathf.Clamp(rotY, cameraSettings[currentCamera].minY, cameraSettings[currentCamera].maxY);

        cameraSettings[currentCamera].cinemachineCamera.transform.localRotation = Quaternion.Euler(rotY, rotX, 0f);

    }
}

[System.Serializable]
public class CameraSetting
{
    public string nameID;
    public GameObject cinemachineCamera;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

}
