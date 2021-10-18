using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OculusInput : MonoBehaviour
{

    public static UnityAction<bool> onHasController = null;

    private bool hasController = false;
    private bool inputActive = true;

    public GameObject player;
    public GameObject grabbed;
    public GameObject controller;

    float disGrab;


    private void Awake()
    {
        OVRManager.HMDMounted += PlayerFound;
        OVRManager.HMDUnmounted += PlayerLost;

    }

    private void OnDestory()
    {
        OVRManager.HMDMounted -= PlayerFound;
        OVRManager.HMDUnmounted -= PlayerLost;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!inputActive)
        {
            return;
        }

        hasController = CheckForController(hasController);

        bool triggerDown = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger);

        bool triggerUp = OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger);

        bool touchPad = OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick);

        // Grab object
        if (triggerDown && grabbed == null)
        {
            RaycastHit hit;

            if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if(hit.collider != null)
                {
                    if (hit.collider.gameObject.tag == "Grabable")
                    {
                        grabbed = hit.collider.gameObject;
                        disGrab = hit.distance;
                    }
                }
            }
        }

        if(grabbed != null)
        {
            grabbed.transform.position = controller.transform.position + controller.transform.forward * disGrab;
            grabbed.transform.rotation = controller.transform.rotation;
        }

        if(triggerUp)
        {
            grabbed = null;
        }

        // Teleport
        if (touchPad)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if(hit.collider.gameObject.tag == "Floor")
                {
                    player.transform.position = hit.point + hit.normal * 4.0f;
                }
            }
        }
    }

    private bool CheckForController(bool currentValue)
    {
        bool controllerCheck = OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote)
            || OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote);

        if(currentValue == controllerCheck)
        {
            return currentValue;
        }
        if(onHasController != null)
        {
            onHasController(controllerCheck);
        }

        return controllerCheck;
    }
    private void PlayerFound()
    {
        inputActive = true;
    }

    private void PlayerLost()
    {
        inputActive = false;
    }
}
