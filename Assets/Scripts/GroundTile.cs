using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundScript groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundScript>();
        SpawnObstacle();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject obstaclePrefab;

    void SpawnObstacle()
    {
        // Choose a random point to spawn the obstacle
        int obstacleSpawnPoint = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnPoint).transform;

        // spawn the obstacle
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

}
