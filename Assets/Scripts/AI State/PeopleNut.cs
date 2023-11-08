using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PeopleNut : PeopleState
{
    public PeopleNut(PeopleStateController psc) : base(psc) { }
    


    public override void OnStateEnter()        // when people enter the walk state, play the  animation
    {
        Debug.Log("Transitioning to nuts");
        psc.agent.isStopped = true;

        

        psc.psa.SetTrigger("TranToNut");

    }

    public override void CheckTransitions()
    {
        if (psc.resetHit)
        {
            psc.psa.SetTrigger("TranToNut");
            psc.resetHit = false;
        }
    }


    public override void Act()
    { 
    }
    public override void OnStateExit()
    {
        psc.hitPlaying = false;
    }

}
