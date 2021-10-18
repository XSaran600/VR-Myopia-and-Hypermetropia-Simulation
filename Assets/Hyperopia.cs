using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyperopia : MonoBehaviour
{
    public GameManager gm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Speedometer")
        {
            if (gm.getCurrentMode() == Mode.Hyperopia)
            {
                gm.Speedometer_Clear.SetActive(true);
                gm.Speedometer_Blur.SetActive(false);
            }
            if (gm.getCurrentMode() == Mode.Myopia)
            {
                gm.Speedometer_Clear.SetActive(false);
                gm.Speedometer_Blur.SetActive(true);
            }
            Debug.Log(other.name);
        }
    }
}
