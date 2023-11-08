using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectionStarter : MonoBehaviour
{
    private NestMaterialTracker materialTracker;
    

    void Start()
    {
        materialTracker = GameObject.Find("Material Tracker").GetComponent<NestMaterialTracker>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(/*UnityEngine.*/Collider other)
    {
        if (other.transform.gameObject.CompareTag("Player"))
        {
            StartMaterialCollection();
            this.gameObject.SetActive(false);
        }

    }

    private void StartMaterialCollection()
    {
        materialTracker.StartCollecting();
        Debug.Log("Collection Starting");
    }

}
