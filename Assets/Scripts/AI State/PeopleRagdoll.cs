using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PeopleRagdoll : PeopleState
{
    public PeopleRagdoll(PeopleStateController psc) : base(psc) { }



    public override void OnStateEnter()        // when people enter the walk state, play the  animation
    {
        EnableRagdoll();
        psc.ragdoll = true;
    }

    public override void CheckTransitions()
    {
    }


    public override void Act()
    {
    }
    public override void OnStateExit()
    {
    }


    private void EnableRagdoll()
    {
        foreach (var rigidbody in psc.ragdollRigidBodies)
        {
            rigidbody.isKinematic = false;
        }
        psc.psa.enabled = false;

/*        psc.agent.isStopped = true;
*/        psc.agent.enabled = false;
        psc.XRGrabInteractable.enabled = true;
    }
}