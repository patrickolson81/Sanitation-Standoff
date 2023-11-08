using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticController : MonoBehaviour
{
    public XRBaseController leftController, rightController;

    public void SendHaptics(bool isLeftController, float amplitute, float duration)
    {
        Debug.Log("isLeftController: " + isLeftController);
        if (isLeftController)
        {
            leftController.SendHapticImpulse(amplitute, duration);
        }
        else if (!isLeftController)
        {
            rightController.SendHapticImpulse(amplitute, duration);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {

        }

    }
}
