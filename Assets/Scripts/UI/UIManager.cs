using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    [SerializeField]
    JoyStickController joystick;


    [SerializeField]
    Stack<GameObject> uiStack = new Stack<GameObject>();

    [SerializeField]
    GameObject test;

    [SerializeField]
    GameObject nowPopupUI;

    void Awake()
    {
        instance = this;
    }

    public bool GetJoystick ()
    {
        return joystick.GetClick();
    }

    public void uiStackPush()
    {
        
    }

    public void uiStackPop()
    {

    }

    public void uiStackClear()
    {

    }
}
