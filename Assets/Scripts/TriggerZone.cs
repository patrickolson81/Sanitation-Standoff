using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class TriggerZone : MonoBehaviour
{
    public string targetTag;
    public UnityEvent<GameObject> onEnterEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            onEnterEvent.Invoke(other.gameObject);
        }
    }
}
