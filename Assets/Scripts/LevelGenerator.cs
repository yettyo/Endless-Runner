using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject groundPrefab;
    public int poolSize = 10;
    public float cubeLength = 200f;
    public float playerOffset = 20f;

    private List<GameObject> cubePool;
    private Transform playerTransform;
    private Vector3 nextSpawnPosition;
    private int currentCubeIndex = 0;

    private ObstacleGenerator obstacleGenerator;

    void Start() 
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        cubePool = new List<GameObject>();

        for(int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(groundPrefab);
            obj.SetActive(false);
            cubePool.Add(obj);
        }

        nextSpawnPosition = Vector3.zero;

        obstacleGenerator = GetComponent<ObstacleGenerator>();

        for(int i = 0; i < poolSize; i++)
        {
            SpawnGroundCube();
        }
    }

    void Update()
    {
        if(playerTransform.position.z + playerOffset > nextSpawnPosition.z)
        {
            RecycleGroundCube();
        }
    }
    
    void SpawnGroundCube()
    {
        GameObject cube = cubePool[currentCubeIndex];
        cube.transform.position = nextSpawnPosition;
        cube.SetActive(true);

        obstacleGenerator.SpawnObstaclesOnLevel(cube);

        nextSpawnPosition += Vector3.forward * cubeLength;

        currentCubeIndex = (currentCubeIndex + 1) % poolSize;
    }
    void RecycleGroundCube()
    {
        cubePool[currentCubeIndex].SetActive(false);

        SpawnGroundCube();
    }

    
}
