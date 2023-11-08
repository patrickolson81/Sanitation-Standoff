using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.GridLayoutGroup;

public class PeopleWalk : PeopleState
{ 
    public PeopleWalk(PeopleStateController psc) : base(psc) { }

    public override void OnStateEnter()// when people enter the walk state, play the walk animation
    {

        psc.psa.SetTrigger("TranToWalk");
        psc.agent.isStopped = false;
        psc.prevStateString = "Walk";
        psc.prevStateTrigger = "TranToWalk";
    }
    public override void CheckTransitions()
    {
        if (psc.agent.remainingDistance <= psc.agent.stoppingDistance && psc.walking) //done with path
        {

            psc.SetState(new PeopleIdle(psc));
            psc.walking = false;
        }


    }
    public override void Act()
    {
        if (!psc.walking)
        {
            Vector3 point;
            if (RandomPoint(psc.centrePoint.position, psc.range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                psc.agent.SetDestination(point);
                psc.walking = true;
            }
        }
    }
    public override void OnStateExit()
    {
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
