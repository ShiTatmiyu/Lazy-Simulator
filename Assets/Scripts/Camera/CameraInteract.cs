using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteract : MonoBehaviour
{
    private CameraControl cameraControl;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Camera cam;
    [SerializeField] private float rayDist;
    [SerializeField] private LayerMask mask;

    void Start()
    {
        cameraControl = gameObject.GetComponent<CameraControl>();    
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rayDist);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, rayDist, mask))
        {
            if (hitInfo.collider.GetComponent<CameraObject>() != null)
            {
                Debug.Log("Raycast");
                int cameraID = hitInfo.collider.GetComponent<CameraObject>().cameraID;
                string onlyNameID = hitInfo.collider.GetComponent<CameraObject>().onlyID;
                if (inputManager.playerAction.Player.Interact.triggered)
                {
                    cameraControl.CameraMove(cameraID, onlyNameID);
                }
            }

            // if ()
            // {

            // }
        }
    }
}
