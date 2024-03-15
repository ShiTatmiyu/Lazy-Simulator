using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ParamToggle : MonoBehaviour
{
    [SerializeField] private GameObject paramObject;
    [SerializeField] private InputManager inputManager;
    private bool paramShown = true;

    // Update is called once per frame
    void Update()
    {
        if(inputManager.playerAction.UI.Toggle.triggered)
        {
            if(paramShown)
            {
                LeanTween.moveY(paramObject,-550,1).setEaseInOutCubic();
                paramShown = false;
            }
            else
            {
                LeanTween.moveY(paramObject,550,1).setEaseInOutCubic();
                paramShown = true;
            }
        }
    }
}
