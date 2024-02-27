using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WatchToggle : MonoBehaviour
{
    [SerializeField] private GameObject watchObject;
    [SerializeField] private InputManager inputManager;
    private bool watchShown = true;

    // Update is called once per frame
    void Update()
    {
        if(inputManager.playerAction.Player.Toggle.triggered)
        {
            if(watchShown)
            {
                LeanTween.moveY(watchObject,-270,1).setEaseInOutCubic();
                watchShown = false;
            }
            else
            {
                LeanTween.moveY(watchObject,270,1).setEaseInOutCubic();
                watchShown = true;
            }
        }
    }
}
