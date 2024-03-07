using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomSetting : MonoBehaviour
{
    [Header("InputManager")]
    [SerializeField] private InputManager inputManager;

    [Header("BroomClick")]
    [SerializeField] private CameraControl cameraControl;
    [SerializeField] private GameObject broomPivot;
    [SerializeField] private Animator anim;
    private bool clickedToggle = false;
    private bool used = false;

    [Header("BroomMove")]
    [SerializeField] private float broomMoveSpeed;
    private Vector2 moveInput;


    // Update is called once per frame
    void Update()
    {
        if (cameraControl.currentCamera == 2)
        {
            anim.SetBool("used", true);
            if (!used)
            {
                anim.SetInteger("currentState", 0);
                used = true;
            }
            if (inputManager.playerAction.Player.LMB.triggered)
            {
                Debug.Log("Clicked");
                if (!clickedToggle)
                {
                    clickedToggle = true;
                    anim.SetInteger("currentState", 1);
                }
                else if (clickedToggle)
                {
                    clickedToggle = false;
                    anim.SetInteger("currentState", 2);
                }
            }
        }
        else
        {
            anim.SetBool("used", false);
            used = false;
            clickedToggle = false;
        }

        HandleBroomMovement();
    }

    private void HandleBroomMovement()
    {
        if (used == true)
        {
            moveInput = inputManager.GetMoveInput();

            Debug.Log(moveInput);
            broomPivot.transform.Translate(new Vector3(moveInput.x, 0, moveInput.y) * (broomMoveSpeed * Time.deltaTime));
        }
    }
}
