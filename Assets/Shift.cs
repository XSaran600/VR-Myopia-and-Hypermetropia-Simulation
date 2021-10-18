using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift : MonoBehaviour
{
    public GameManager gm;

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (gm.getCurrentMode() != Mode.Hyperopia)
            {
                gm.setCurrentMode(Mode.Hyperopia);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (gm.getCurrentMode() != Mode.Myopia)
            {
                gm.setCurrentMode(Mode.Myopia);
            }
        }
        */
        
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            if (gm.getCurrentMode() != Mode.Hyperopia)
            {
                gm.setCurrentMode(Mode.Hyperopia);
            }
        }
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            if (gm.getCurrentMode() != Mode.Myopia)
            {
                gm.setCurrentMode(Mode.Myopia);
            }
        }
        
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Normal")
        {
            Debug.Log("Normal");
            if (gm.getCurrentMode() != Mode.Normal)
            {
                gm.setCurrentMode(Mode.Normal);
            }
        }
        if (other.name == "Hyperopia")
        {
            if (gm.getCurrentMode() != Mode.Hyperopia)
            {
                gm.setCurrentMode(Mode.Hyperopia);
            }
        }
        if (other.name == "Myopia")
        {
            if (gm.getCurrentMode() != Mode.Myopia)
            {
                gm.setCurrentMode(Mode.Myopia);
            }
        }
    }
*/
}
