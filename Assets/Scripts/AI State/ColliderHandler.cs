using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.XR.Interaction.Toolkit;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.XR.Interaction.Toolkit;

public class ColliderHandler : MonoBehaviour
{
    private PeopleStateController psc;
    private HapticController hapticController;

    private XRDirectInteractor rHand;
    private XRDirectInteractor lHand;

    private ControllerVelocity leftVelocityTrack;
    private ControllerVelocity rightVelocityTrack;

    private Vector3 leftVelocity;
    private Vector3 rightVelocity;
    

    void Start()
    {
        psc = GetComponentInParent<PeopleStateController>();
        hapticController = GameObject.Find("XR Origin (XR Rig)").GetComponent<HapticController>();
        rHand = GameObject.Find("Right Direct Interactor").GetComponent<XRDirectInteractor>();
        lHand = GameObject.Find("Left Direct Interactor").GetComponent<XRDirectInteractor>();
        leftVelocityTrack = GameObject.Find("Left Controller").GetComponent<ControllerVelocity>();
        rightVelocityTrack = GameObject.Find("Right Controller").GetComponent<ControllerVelocity>();


        psc.hitPlaying = false;
        psc.resetHit = false;

        
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision.gameobject.name: " + collision.gameObject.name);
            if (collision.gameObject.name == "Right Controller") // if the colliding gameobject is the right hand -- send haptics
            {
                hapticController.SendHaptics(false, 1f, .5f);
                rightVelocity = rightVelocityTrack.velocity;
                Debug.Log(rightVelocity.magnitude);
            }
            else if (collision.gameObject.name == "Left Controller")// if the colliding gameobject is the left hand -- send haptics
            {
                hapticController.SendHaptics(true, 1f, .5f);
                leftVelocity = leftVelocityTrack.velocity;
                Debug.Log(leftVelocity.magnitude);

            }
            if (psc.walking && !psc.hitPlaying && ((leftVelocity.magnitude < 1.5f) || (rightVelocity.magnitude < 1.5f))) // if the person is walking, and the player hasnt been hit already send to shove state
            {
                psc.SetState(new PeopleShove(psc));
            }
            if (psc.hitPlaying) // if the nut animation is playing, and the player is hit again, reset the animation
            {
                psc.resetHit = true;
            }
            if (!psc.hitPlaying && !psc.walking) // if the nut animation isnt playing, the person isnt walking and gets hit, play the nut animation
            {
                psc.hitPlaying = true;
                psc.SetState(new PeopleNut(psc));
            }
            if (leftVelocity.magnitude > 4f ||  rightVelocity.magnitude > 4f)
            {
                psc.SetState(new PeopleRagdoll(psc));
            }


        }
        if (collision.gameObject.CompareTag("Trash"))
        {
            XRGrabInteractable grabInteractable = collision.gameObject.GetComponent<XRGrabInteractable>();

            XRInteractionManager hand = grabInteractable.GetComponent<XRInteractionManager>();
            hand.

            if (hand != null)
            {
                // Get the interactable's attached XR Controller
                Debug.Log("Hand holding trash is :" + hand);

                
            }
        }

        /*Debug.Log(rHand.interactablesSelected(rHand[0])[0]; *//*
        if (rHand.selectEntered.ToString() == "Trash")
        {
            hapticController.SendHaptics(false, 1f, .5f);
        }
        else if (lHand.selectEntered.ToString() == "Gun")
        {
            hapticController.SendHaptics(true, 1f, .5f);
        }*/
    }
}
