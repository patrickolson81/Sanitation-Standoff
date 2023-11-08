using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWhenHit : MonoBehaviour
{
    public List<GameObject> breakablePieces;

    public ParticleSystem glassBreakParticles, glassBreakPrefab;

    private float velThreshold = 1f;
    private float velocity;
    private Rigidbody rb;

    void Start()
    {
        /*rb = GetComponent<Rigidbody>();*/

        foreach (var piece in breakablePieces)
        {
            piece.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      // Get the velocity of the thrown object

    }
    private void OnCollisionEnter(Collision collision)
    {

        // Check if the collision involves a surface
        if (!collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("object" + collision.gameObject);
            rb = collision.gameObject.GetComponent<Rigidbody>();
            velocity = rb.velocity.magnitude;
            AudioManager.instance.Play("GlassBreak");
            Debug.Log("velocity " + velocity );



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
        glassBreakParticles = ParticleSystem.Instantiate(glassBreakPrefab, this.transform.position, Quaternion.identity);
        glassBreakParticles.Play();

        gameObject.SetActive(false);
    }
}
