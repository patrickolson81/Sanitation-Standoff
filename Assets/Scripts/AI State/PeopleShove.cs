using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PeopleShove : PeopleState
{
    public PeopleShove(PeopleStateController psc) : base(psc) { }



    public override void OnStateEnter()        // when people enter the walk state, play the  animation
    {
        Debug.Log("Transitioning to shove");
        



        psc.psa.SetTrigger("TranToShove");

    }

    public override void CheckTransitions()
    {
        if (psc.resetHit)
        {
            psc.psa.SetTrigger("TranToShove");
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
