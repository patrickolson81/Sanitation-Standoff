using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLook : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    void Update()
    {
        // Ensure the text faces the camera
        transform.LookAt(Camera.main.transform);

        // Optional: Rotate the text 180 degrees around the y-axis if needed
        transform.Rotate(0, 180, 0);

        /*Vector3 LookVector = new Vector3(Player.transform.position.x, 0, Player.transform.position.z);
        transform.LookAt(LookVector);*/
        //(transform.position - Player.transform.position); 

        //transform.LookAt((Camera.main.transform));
    }
}
