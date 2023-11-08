using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTrack : MonoBehaviour
{

    public int numberOfTaggedObjects;
    private bool checking = false;


    // Update is called once per frame
    void Update()
    {

        if (!checking)
        {

            StartCoroutine(DelayedCall());
        }
    }
    IEnumerator DelayedCall()
    {
        checking = true;
        yield return new WaitForSeconds(3f); // Wait for 5 seconds
        CheckTrashAmount(); // Call your method after the delay
    }

    void CheckTrashAmount()
    {
        numberOfTaggedObjects = GameObject.FindGameObjectsWithTag("TrashItems").Length;
        checking = false;
    }
    
}
