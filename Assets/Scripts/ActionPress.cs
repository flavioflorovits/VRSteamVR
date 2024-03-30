using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActionPress : MonoBehaviour
{

    public SteamVR_Action_Boolean myCustomActionBoolean;

    public SteamVR_Input_Sources handType;

    private void Start()
    {
        myCustomActionBoolean.AddOnStateDownListener(TriggerDown, handType);
        myCustomActionBoolean.AddOnStateUpListener(TriggerUp, handType);
    }

    public void LogPress()
    {
        Debug.Log("A button has been pressed!");
    }

    public void TriggerUp(SteamVR_Action_Boolean function, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Button up");
    }

    public void TriggerDown(SteamVR_Action_Boolean function, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Button down");
    }

}
