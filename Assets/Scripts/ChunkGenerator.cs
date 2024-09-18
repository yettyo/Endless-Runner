using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public GameObject initialChunkPrefab;
    public GameObject[] chunkPrefabs;  
    public int poolSize = 10;           
    public float chunkLength = 200f;   
    public float playerOffset = 20f;  

    private Transform playerTransform; 
    private Vector3 nextSpawnPosition; 
    private int currentChunkIndex = 0; 
    private List<GameObject> chunkPool;
    private bool hasSpawnedInitialChunk = false;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        chunkPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject chunk = Instantiate(chunkPrefabs[Random.Range(0, chunkPrefabs.Length)]);
            chunk.SetActive(false);
            chunkPool.Add(chunk);
        }

        nextSpawnPosition = Vector3.zero;

        SpawnInitialChunk();

        for (int i = 0; i < poolSize; i++)
        {
            SpawnChunk();
        }
    }

    private void SpawnInitialChunk()
    {
        if(!hasSpawnedInitialChunk)
        {
            GameObject initialChunk = Instantiate(initialChunkPrefab);
            initialChunk.transform.position = nextSpawnPosition;
            initialChunk.SetActive(true);
            nextSpawnPosition += Vector3.forward * chunkLength;
            hasSpawnedInitialChunk = true;
        }
    }

    void Update()
    {
        if (playerTransform.position.z + playerOffset > nextSpawnPosition.z)
        {
            RecycleChunk();
        }
    }

    private void SpawnChunk()
    {
        GameObject chunk = chunkPool[currentChunkIndex];

        chunk.transform.position = nextSpawnPosition;
        chunk.SetActive(true);

        nextSpawnPosition += Vector3.forward * chunkLength;

        currentChunkIndex = (currentChunkIndex + 1) % poolSize;
    }
    private void RecycleChunk()
    {
        chunkPool[currentChunkIndex].SetActive(false);

        SpawnChunk();
    }
}
