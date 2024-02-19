using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    public CameraSetting[] cameraSettings;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class CameraSetting
{
    [SerializeField] private string nameID; 
    [SerializeField] private CinemachineVirtualCamera cinemachineCamera;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;
    [SerializeField] private float minX;
    [SerializeField] private float minY;
}
