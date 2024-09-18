using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
    private float startingZ;

    void Start()
    {
        startingZ = player.position.z;
    }

    void Update()
    {
        float distanceTraveled = player.position.z - startingZ;

        scoreText.text = "Score: " + Mathf.FloorToInt(distanceTraveled).ToString();
    }
}