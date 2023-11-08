using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingAlpha : MonoBehaviour
{
public float pulseSpeed = 1f; // the speed at which the alpha value pulses
    public float minAlpha = 0.9f; // the minimum alpha value for the pulsing effect
    public float maxAlpha = 1f; // the maximum alpha value for the pulsing effect
    public float startDelay = 2f; // the amount of time to wait before starting the pulsing effect

    private bool isPulsing = false;
    private float currentAlpha = 0f;
    private MeshRenderer render;

    private enum Purpose{DIVORCE, BULLYING, BREAKUP, WEDDING, COOKIE};
    [SerializeField] private Purpose purpose;

    private EventTracker eventTracker;

    public bool cookieClicked = false;

    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (isPulsing)
        {
            currentAlpha = Mathf.Lerp(minAlpha, maxAlpha, Mathf.PingPong(Time.time * pulseSpeed, 1f));
            Color color = render.material.color;
            color.a = currentAlpha;
            render.material.color = color;
        }
        else
        {

            Color color = render.material.color;
            color.a = 0f;
            render.material.color = color;
        }
    }

    public void PulseEnable()
    {
        if(!isPulsing)
        {
            Invoke("StartPulsing", startDelay);
        }
    }

    public void StartPulsing()
    {
        if (!isPulsing)
        {
             isPulsing = true;
             Debug.Log("is starting");
        }
    }

    public void StopPulsing()
    {
        isPulsing = false;
    }
}
