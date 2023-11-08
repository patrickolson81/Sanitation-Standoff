using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NestMaterialTracker : MonoBehaviour
{
    private NestMaterialText materialText;
    private NestMaterialSpawner materialSpawner;
    private PulsingAlpha pulsing;

    private bool collecting;
    private bool roundSpawning = true; // change this if you dont want rounds of spawning (Only collect objects once)
    private int numberNeeded = 6;
    private int numNeededToSpawnAgain = 3; //amount to collect before more spawn --- disable round spawning if you dont want this
    private int currentNumber = 0;


    void Start()
    {
        collecting = false;
        materialText = GameObject.Find("Material Text").GetComponent<NestMaterialText>();
        materialSpawner = GameObject.Find("MaterialSpawner").GetComponent<NestMaterialSpawner>();
    }

    private void OnTriggerEnter(Collider enter) 
    {
       if (collecting)
        {
            if (enter.transform.gameObject.CompareTag("NestMat"))
            {
                Debug.Log("Material Collected");
                materialText.AddMaterial();
                Destroy(enter.gameObject);
                currentNumber++;
            }
        }
        else
        {
            return;
        }
       if (collecting && roundSpawning && currentNumber == numNeededToSpawnAgain)
        {
            SpawnAgain();
        }
       if (currentNumber >= numberNeeded)
        {
            StopCollecting();
        }
    }
    public void StartCollecting()
    {
        materialText.ShowText();
        collecting = true;
        materialSpawner.StartSpawning();
    }

    private void SpawnAgain()
    {
        materialSpawner.StartSpawning();
    }
    public void StopCollecting()
    {
        collecting = false;
        materialText.ChangeText();
        StartCoroutine(HideText());
    }
    IEnumerator HideText()
    {
        // Wait for one second
        yield return new WaitForSeconds(3f);

        // Call method here
        materialText.HideText();

    }

}
