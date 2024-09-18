using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
    private float startingZ;
    private int currentScore;

    void Start()
    {
        startingZ = player.position.z;
    }

    void Update()
    {
        float distanceTraveled = player.position.z - startingZ;

        currentScore = Mathf.FloorToInt(distanceTraveled);
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        PlayerPrefs.Save();
    }
}