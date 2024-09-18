using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("CurrentScore");
        currentScoreText.text = finalScore.ToString();
    }
}
