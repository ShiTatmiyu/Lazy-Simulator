using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    [Header("Camera Option")]
    [SerializeField] private CameraSetting[] cameraSettings;

    [Header("InputManager")]
    [SerializeField] private InputManager inputManager;
    private int previousCamera;
    public int currentCamera;

    // Start is called before the first frame update
    void Start()
    {
        previousCamera = 0;
        currentCamera = 0;
    }

    private void Update()
    {
        if(inputManager.playerAction.UI.Back.triggered && cameraSettings[currentCamera].isChild)
        {
            CameraMove(previousCamera);
        }
    }

    public void CameraMove(int cameraID)
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
        previousCamera = currentCamera;
        currentCamera = cameraID;
    }
}



[System.Serializable]
public class CameraSetting
{
    public string nameID;
    public GameObject cinemachineCamera;
    public bool isChild;
}
