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
    public int currentCamera;
    private float mouseX;
    private float mouseY;
    private float rotY = 0f;
    private float rotX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentCamera = 0;
    }

    public void CameraMove(int cameraID, string onlyNameID)
    {
        if (onlyNameID == cameraSettings[currentCamera].nameID || onlyNameID == "none")
        {
            for (int i = 0; i < cameraSettings.Length; i++)
            {
                CinemachineVirtualCamera cinemachine = cameraSettings[i].cinemachineCamera.GetComponent<CinemachineVirtualCamera>();
                if (i == cameraID)
                {
                    cinemachine.Priority = 2;
                }
                else
                {
                    cinemachine.Priority = 1;
                }
            }
            currentCamera = cameraID;
        }
    }
}



[System.Serializable]
public class CameraSetting
{
    public string nameID;
    public GameObject cinemachineCamera;
}
