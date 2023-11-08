using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EventTracker : MonoBehaviour
{
    private NestMaterialTracker materialTracker;
    private InputData _inputData;

    private bool collectionStarted = false;
    private bool buttonClicked = false;


    // Start is called before the first frame update
    void Start()
    {
        materialTracker = GameObject.Find("Material Tracker").GetComponent<NestMaterialTracker>();
        _inputData = GetComponent<InputData>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!collectionStarted && !buttonClicked)
        {
            if (_inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool _aButtonPressed))
            {
                if (_aButtonPressed)
                {
                    Debug.Log(_aButtonPressed);
                    StartMaterialCollection();
                    collectionStarted = true;
                    buttonClicked = true;   // set a bool for button pressed, then start coroutine to wait one second before allowing the button press to be detected again
                    StartCoroutine(DelayedMethod());
                    Debug.Log("A Button Pressed, Collection Started: " + collectionStarted);
                }

            }
        }
        if (collectionStarted && !buttonClicked)
        {
            if (_inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool _aButtonPressed))
            {
                if (_aButtonPressed)
                {
                    Debug.Log("_aButtonPressed");
                    StopMaterialCollection();
                    buttonClicked = true;   // set a bool for button pressed, then start coroutine to wait one second before allowing the button press to be detected again
                    StartCoroutine(DelayedMethod());
                    collectionStarted = false;
                }
            }
        }


    }

    //Method to begin the search for nest materials
    private void StartMaterialCollection() 
    {
        materialTracker.StartCollecting();
    }
    private void StopMaterialCollection()
    {
        materialTracker.StopCollecting();
    }

    IEnumerator DelayedMethod()
    {
        // Wait for one second
        yield return new WaitForSeconds(.5f);

        // Call your method here
        ResetButton();
    }
    void ResetButton()
    {
        buttonClicked = false;
    }
}
