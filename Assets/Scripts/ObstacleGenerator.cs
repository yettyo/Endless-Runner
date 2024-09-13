using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public int obstaclePoolSize = 20;

    private List<GameObject> obstaclePool;
    private int currentObstacleIndex = 0;

    void Start()
    {
        obstaclePool = new List<GameObject>();

        for(int i = 0; i < obstaclePoolSize; i++)
        {
            GameObject selectedObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            GameObject obj = Instantiate(selectedObstacle);
            obj.SetActive(false);
            obstaclePool.Add(obj);
        }
    }

    public void SpawnObstaclesOnLevel(GameObject groundCube)
    {
        int numObstacles = Random.Range(1, 4);
        
        for(int i = 0; i < numObstacles; i++)
        {
            GameObject obstacle = obstaclePool[currentObstacleIndex];
            GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 prefabLocalPosition = prefab.transform.localPosition;
            Vector3 obstaclePosition = groundCube.transform.position 
            + new Vector3(prefabLocalPosition.x, prefabLocalPosition.y, Random.Range(-50, 50));

            obstacle.transform.position = obstaclePosition;
            obstacle.SetActive(true);

            currentObstacleIndex = (currentObstacleIndex + 1) % obstaclePool.Count;
        }
    }
}
