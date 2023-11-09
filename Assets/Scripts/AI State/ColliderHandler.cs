using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.OpenVR;
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
        if (!psc.ragdoll) // if the NPC isnt ragdolled -- continue
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Collision.gameobject.name: " + collision.gameObject.name);


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
                if (leftVelocity.magnitude > 4f || rightVelocity.magnitude > 4f)
                {
                    psc.SetState(new PeopleRagdoll(psc));
                }



                if (collision.gameObject.name == "Right Controller") // if the colliding gameobject is the right hand -- send haptics
                {
                    hapticController.SendHaptics(false, 1f, .5f);
                    rightVelocity = rightVelocityTrack.velocity;
                }
                else if (collision.gameObject.name == "Left Controller")// if the colliding gameobject is the left hand -- send haptics
                {
                    hapticController.SendHaptics(true, 1f, .5f);
                    leftVelocity = leftVelocityTrack.velocity;

                }
            }
            if (collision.gameObject.CompareTag("Trash"))  // If the object has the tag trash, get the hand tracker script from the colliding object, get which hand is holding it, then send haptics
            {
                XRGrabHandTrack handTrack = collision.gameObject.GetComponent<XRGrabHandTrack>();

                if (handTrack != null)
                {
                    return;
                }
                else if (handTrack.handHolding.CompareTag("Left Hand"))
                {
                    hapticController.SendHaptics(true, 1f, .5f);
                    leftVelocity = leftVelocityTrack.velocity;
                }
                else if (handTrack.handHolding.CompareTag("Right Hand"))
                {
                    hapticController.SendHaptics(false, 1f, .5f);
                    rightVelocity = rightVelocityTrack.velocity;
                }
            }
        }
    }
}
