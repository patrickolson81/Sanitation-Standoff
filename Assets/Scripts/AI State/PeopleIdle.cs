using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PeopleIdle : PeopleState
{
    public PeopleIdle(PeopleStateController psc) : base(psc) { }

    private string idleTrigger;

    public override void OnStateEnter()
    {
        // when person enters idle state, play the idle animation
        int random = GenerateRandomNumber(0, psc.idle.Length);
        
        psc.prevStateString = "Idle";

        string trigger = psc.idle[random];
        psc.psa.SetTrigger(trigger);


    }
    public override void CheckTransitions() // check to see if something happens, then do something
    {
        if (!psc.waiting)
        {
            psc.WaitToWalk();

        }
/*        Collider collider = psc.GetComponent<Collider>();
       
        if (collider != null && collider.CompareTag("Player"))
        {
            Debug.Log("Collision.gameobject.name: " + collider.gameObject.name);
            if (collider.gameObject.name == "Right Controller")
            {
                psc.hapticController.SendHaptics(false, 1f, .5f);
            }
            else if (collider.gameObject.name == "Left Controller")
            {
                psc.hapticController.SendHaptics(true, 1f, .5f);
            }
            psc.SetState(new PeopleNut(psc));
        }*/

    }

    public override void Act() // do this when between transitions
    { }

    public override void OnStateExit() { }

    int GenerateRandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }

    int GetRandomIdle()
    {
        int randomIndex = Random.Range(0, psc.idle.Length);
        return randomIndex;
    }
/*    private void OnColliderEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision.gameobject.name: " + collision.gameObject.name);
            if (collision.gameObject.name == "Right Controller")
            {
                psc.hapticController.SendHaptics(false, 1f, .5f);
            }
            else if (collision.gameObject.name == "Left Controller")
            {
                psc.hapticController.SendHaptics(true, 1f, .5f);
            }
            psc.SetState(new PeopleNut(psc));
        }
    }*/
}
