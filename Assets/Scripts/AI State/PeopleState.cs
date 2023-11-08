using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public abstract class PeopleState
{
    protected PeopleStateController psc;

    public abstract void CheckTransitions();
    public abstract void Act();
    public abstract void OnStateEnter();
    public abstract void OnStateExit();

    public PeopleState(PeopleStateController psc )
    {
        this.psc = psc;
    }
}
