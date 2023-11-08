using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabHandTrack : MonoBehaviour
{
    private XRBaseInteractor grabbingInteractor;

    private void OnEnable()
    {
        // Subscribe to grab events
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnGrab);
        GetComponent<XRGrabInteractable>().selectExited.AddListener(OnRelease);
    }

    private void OnGrab(BaseInteractionEventArgs arg0)
    {
        OnGrab(arg0);
    }
    private void OnRelease(BaseInteractionEventArgs arg1)
    {
        OnRelease(arg1.);
    }
    private void OnDisable()
    {
        // Unsubscribe from grab events to prevent memory leaks
        GetComponent<XRGrabInteractable>().selectEntered.RemoveListener(OnGrab);
        GetComponent<XRGrabInteractable>().selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        // Store the grabbing interactor (hand)
        grabbingInteractor = interactor;

        // Log the name of the grabbing hand
        Debug.Log($"Grabbed by {interactor.gameObject.name}");
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        // Log the name of the releasing hand
        Debug.Log($"Released by {interactor.gameObject.name}");

        // Clear the grabbing interactor when released
        grabbingInteractor = null;
    }

    // You can use grabbingInteractor elsewhere in your script to identify the grabbing hand
}
