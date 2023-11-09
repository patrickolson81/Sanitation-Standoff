using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabHandTrack : MonoBehaviour
{
    private XRBaseInteractor grabbingInteractor;

    public GameObject handHolding;

    private void OnEnable()
    {
        // Subscribe to grab events
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnGrab);
        GetComponent<XRGrabInteractable>().selectExited.AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs arg0)
    {
        // Check if the interactable object is an XRBaseInteractable
        if (arg0.interactableObject is XRBaseInteractable interactable)
        {
            // Extract the interactor from SelectEnterEventArgs
            XRBaseInteractor interactor = (XRBaseInteractor)arg0.interactorObject;

            // Call the modified OnGrab method
            OnGrab(interactor);
        }
    }


    private void OnGrab(XRBaseInteractor interactor)
    {
        // Handle grab logic
        Debug.Log($"Grabbed by {interactor.gameObject.name}");
        handHolding = interactor.gameObject;
    }

    private void OnRelease(SelectExitEventArgs arg1)
    {
        // Check if the interactable object is an XRBaseInteractable
        if (arg1.interactableObject is XRBaseInteractable interactable)
        {
            // Extract the interactor from SelectExitEventArgs
            XRBaseInteractor interactor = (XRBaseInteractor)arg1.interactorObject;

            // Call the modified OnRelease method
            OnRelease(interactor);
        }
    }
    private void OnRelease(XRBaseInteractor interactor)
    {
        // Handle release logic
        Debug.Log($"Released by {interactor.gameObject.name}");
        handHolding = null;
    }

    private void OnDisable()
    {
        // Unsubscribe from grab events to prevent memory leaks
        GetComponent<XRGrabInteractable>().selectEntered.RemoveListener(OnGrab);
        GetComponent<XRGrabInteractable>().selectExited.RemoveListener(OnRelease);
    }
}