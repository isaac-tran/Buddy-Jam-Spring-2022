using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlatform : MonoBehaviour
{
    //reference the switch from which the platform recieves commands
    public Switch Switch;

    bool isGlitched = false;
    // Update is called once per frame
    void Update()
    {
        if(Switch.switchstate == true)
        {
            if(isGlitched)
            {
                return;
            }

            isGlitched = true;
            Debug.Log("Glitched");
        }

    }
}
