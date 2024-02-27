using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    [Header("Camera Option")]
    [SerializeField] private CameraSetting[] cameraSettings;

    [Header("InputManager")]
    public int currentCamera;

    // Start is called before the first frame update
    void Start()
    {
        currentCamera = 0;
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
        currentCamera = cameraID;
    }
}



[System.Serializable]
public class CameraSetting
{
    public string nameID;
    public GameObject cinemachineCamera;
}
