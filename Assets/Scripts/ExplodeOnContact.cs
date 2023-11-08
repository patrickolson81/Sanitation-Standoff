using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnContact : MonoBehaviour
{
    [Header("Trash Pieces")]
    public List<GameObject> breakablePieces;

    public ParticleSystem explodeParticles, explosionPrefab;
    public GameObject pointPopup;


    private float velThreshold = 5f;
    private float velocity;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        foreach (var piece in breakablePieces)
        {
            piece.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = rb.velocity.magnitude;            // Get the velocity of the thrown object

    }
    private void OnCollisionEnter(Collision collision)
    {

        // Check if the collision involves a surface
        if (!collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.Play("TrashBreak");


            // Check if the velocity is above the threshold
            if (velocity > velThreshold)
            {
                // Do something when the conditions are met
                Debug.Log("High-speed collision with surface!");
                Break();

                // Add your custom logic here
            }
        }
    }

    public void Break()
    {
        foreach (var piece in breakablePieces)
        {
            piece.SetActive(true);
            piece.transform.parent = null;            
        }
        Instantiate(pointPopup, this.transform.position, Quaternion.identity);
        

        explodeParticles = ParticleSystem.Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
        explodeParticles.Play();
        gameObject.SetActive(false);
    }
}
