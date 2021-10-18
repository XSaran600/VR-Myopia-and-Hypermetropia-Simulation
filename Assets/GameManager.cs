using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Mode { Normal, Hyperopia, Myopia };
// hyperopia (far-sightedness) Can see DISTANT objects very well, but have difficulty focusing on objects that are up NEAR
// mypoia (near-sightedness) Can see objects NEAR to you clearly, but objects at a DISTANT are blurry

public class GameManager : MonoBehaviour
{
    public Mode currentMode = Mode.Normal;

    public GameObject Speedometer_Clear;
    public GameObject Speedometer_Blur;

    public GameObject StreetSign_Clear;
    public GameObject StreetSign_Blur;

    private void Start()
    {
        change();
    }
    /*
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if (getCurrentMode() != Mode.Hyperopia)
            {
                setCurrentMode(Mode.Hyperopia);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (getCurrentMode() != Mode.Myopia)
            {
                setCurrentMode(Mode.Myopia);
            }
        }
    }
    */
    public Mode getCurrentMode()
    {
        return currentMode;
    }

    public void setCurrentMode(Mode mode)
    {
        currentMode = mode;

        change();
    }

    public void change()
    {
        if (currentMode == Mode.Normal)
        {
            Speedometer_Clear.SetActive(true);
            Speedometer_Blur.SetActive(false);

            StreetSign_Clear.SetActive(true);
            StreetSign_Blur.SetActive(false);
        }
        if (currentMode == Mode.Hyperopia)
        {
            Speedometer_Clear.SetActive(false);
            Speedometer_Blur.SetActive(true);

            StreetSign_Clear.SetActive(true);
            StreetSign_Blur.SetActive(false);
        }
        if (currentMode == Mode.Myopia)
        {
            Speedometer_Clear.SetActive(true);
            Speedometer_Blur.SetActive(false);

            StreetSign_Clear.SetActive(false);
            StreetSign_Blur.SetActive(true);
        }

    }
}
