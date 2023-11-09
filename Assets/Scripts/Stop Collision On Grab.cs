using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCollisionOnGrab : MonoBehaviour
{
    [SerializeField] private int objectLayerInt;
    private int holdingLayerInt = 8;
    public void DisableCollision() // disable the collision between the object and the player when picked up by changing the layer to the "holding" layer
    {
        gameObject.layer = holdingLayerInt;
    }
    public void EnableCollisions() 
    { 
        gameObject.layer = objectLayerInt;
    }
}
