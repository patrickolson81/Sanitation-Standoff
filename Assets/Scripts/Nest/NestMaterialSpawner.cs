using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NestMaterialSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _nestMaterial;
    [SerializeField] private Material[] materials;

    private PulsingAlpha pulsing;

    private Transform spawnPos;
    private Vector3[] spawnPositions;

    private int childCount;
    private int spawnAmount = 3; // amount of "nest materials" to spawn
    void Start()
    {
        pulsing = GetComponent<PulsingAlpha>();
        spawnPos = GameObject.Find("SpawnPositions").GetComponent<Transform>();

        childCount = spawnPos.childCount;
        CollectEmptyObjectPositions();
    }
    void CollectEmptyObjectPositions() // get the spawn positions from the empty gameobjects under the spawn Positions object
    {
        
        spawnPositions = new Vector3[childCount];
        for (int i = 0; i < childCount; i++)
        {
            // Get the position of each empty object
            spawnPositions[i] = spawnPos.GetChild(i).position;
        }
    }

    public void StartSpawning()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            SpawnObjects();
        }
    }

    void SpawnObjects()
    {
        Debug.Log("Starting Spawn");
        if (spawnPositions.Length > 0)
        {
            // Randomly pick a material from the array
            Material selectedMaterial = materials[Random.Range(0, materials.Length)];

            // Choose a random spawn position
            int randomIndex = Random.Range(0, spawnPositions.Length);
            Vector3 spawnPosition = spawnPositions[randomIndex];

            // Spawn the object at the chosen position and assign the selected material also start the pulsing alpha script
            GameObject nestMaterial = Instantiate(_nestMaterial, spawnPosition, Quaternion.identity);
            nestMaterial.GetComponent<Renderer>().material = selectedMaterial;
            nestMaterial.GetComponent<PulsingAlpha>().StartPulsing();
            // Remove the used spawn position from the array
            RemoveSpawnPosition(randomIndex);
        }
        else
        {
            Debug.LogWarning("No spawn positions available.");
        }
    }
    void RemoveSpawnPosition(int index)
    {
        // Create a new array excluding the used position
        spawnPositions = spawnPositions.Where((_, i) => i != index).ToArray();
    }


}
