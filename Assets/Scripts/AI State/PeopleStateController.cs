using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;

public class PeopleStateController : MonoBehaviour
{
    public HapticController hapticController;

    public PeopleState currentState;
    public Animator psa;
    public string prevStateTrigger;
    public string prevStateString;

    public NavMeshAgent agent;
    public float range; //radius of sphere

    public Transform centrePoint; //centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area

    [Header("Animations")]
    public string[] idle;
    public string walk;

    public bool waiting = false;
    public bool walking = false;
    public bool hitPlaying;
    public bool resetHit;
    public bool ragdoll = false;

    public Rigidbody[] ragdollRigidBodies { get; private set; }

    public XRGrabInteractable XRGrabInteractable;



    void Start()
    {
        psa = GetComponent<Animator>();


        SetState(new PeopleIdle(this));
        ragdollRigidBodies = GetComponentsInChildren<Rigidbody>();
        XRGrabInteractable = GetComponentInChildren<XRGrabInteractable>();
        XRGrabInteractable.enabled = false;
        DisableRagdoll();


    }

    // Update is called once per frame
    void Update()
    {
        
        currentState.CheckTransitions();
        currentState.Act();
    }

    public void SetState(PeopleState state)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    }

    public void AnimationControl(string da)
    {
        psa.Play(da);
    }
    public void WaitToWalk()
    {
        if (!waiting)
        {
            StartCoroutine(DelayedCall());

        }
    }
    IEnumerator DelayedCall()
    {
        waiting = true;
        float random = GenerateRandomNumber(5, 15);
        yield return new WaitForSeconds(random); // Wait for 5 seconds

        ChangeToWalking(); // Call your method after the delay
    }
    private void ChangeToWalking()
    {
        if (!ragdoll)
        {
            SetState(new PeopleWalk(this));
            waiting = false;
        }

    }
    float GenerateRandomNumber(float min, float max)
    {
        return Random.Range(min, max + 1);
    }

    public void ReturnToPrevState()
    {
        hitPlaying = false;
        if (prevStateTrigger == null)
        {
            return;
        }
        else
        {
            psa.SetTrigger(prevStateTrigger);
            if (prevStateString == "Walk")
            {
/*                prevStateString = "Nut";
*/                SetState(new PeopleWalk(this));
            }
            if (prevStateString == "Idle")
            {
                /*prevStateString = "Nut";*/
                SetState(new PeopleIdle(this));
            }
        }

    }

    private void DisableRagdoll()
    {
        foreach (var rigidbody in ragdollRigidBodies)
        {
            rigidbody.isKinematic = true;
        }
    }

    public void EnableRagdoll()
    {
        foreach (var rigidbody in ragdollRigidBodies)
        {
            rigidbody.isKinematic = false;
        }
        psa.enabled = false;
        
        agent.isStopped = true;
    }
}
