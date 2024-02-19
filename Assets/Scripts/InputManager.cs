using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerAction playerAction;

    void Start()
    {
        playerAction = new PlayerAction();
        playerAction.Player.Enable();
    }

    public Vector2 GetLookInput()
    {
        Vector2 lookDir = playerAction.Player.Look.ReadValue<Vector2>();

        return lookDir;
    }
}
