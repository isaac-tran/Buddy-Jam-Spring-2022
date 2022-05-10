using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlatform : MonoBehaviour
{
    //reference the switch from which the platform recieves commands
    public Switch Switch;
    public BoxCollider Collision;
    private Behaviour collision;

    bool isGlitched = false;
    // Update is called once per frame
    void Update()
    {
        if(Switch.switchstate != isGlitched)
        {
            if(isGlitched == false){
                gameObject.layer = LayerMask.NameToLayer("GlitchDimension");

                Collision.enabled = true;

                isGlitched = true;
                Debug.Log("Glitched");
            }
            
            else //i'm not sure if this check works?
            {
                gameObject.layer = LayerMask.NameToLayer("Default");

                Collision.enabled = false;

                isGlitched = false;
                Debug.Log("UnGlitched");
            }
        }

    }
}
