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
        playerAction.UI.Enable();
        playerAction.Debug.Enable();
    }

    public Vector2 GetMoveInput()
    {
        Vector2 moveDir = playerAction.Player.Move.ReadValue<Vector2>();

        return moveDir;
    }
}
