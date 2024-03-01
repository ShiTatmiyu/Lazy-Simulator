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
    private ParamSetting paramSetting;

    void Start()
    {
        cameraControl = gameObject.GetComponent<CameraControl>();
        paramSetting = gameObject.GetComponent<ParamSetting>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rayDist);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, rayDist, mask))
        {
            if (inputManager.playerAction.UI.Interact.triggered)
            {
                if (hitInfo.collider.GetComponent<CameraObject>() != null)
                {
                    Debug.Log("Raycast Camera");
                    int cameraID = hitInfo.collider.GetComponent<CameraObject>().cameraID;

                    cameraControl.CameraMove(cameraID);

                }
                if (hitInfo.collider.GetComponent<ParamModifier>() != null)
                {
                    Debug.Log("Raycast Param");
                    ParamModifier paramModifier = hitInfo.collider.GetComponent<ParamModifier>();

                    paramSetting.UpdateParam(paramModifier.paramID, paramModifier.value);
                }
            }
        }
    }
}
