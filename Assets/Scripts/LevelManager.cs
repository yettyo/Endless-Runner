using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadMainMenu() {
        SceneManager.LoadScene(0);
    }
    public void LoadGame() {
        SceneManager.LoadScene(1);
    }
    public void LoadGameOver() {
        SceneManager.LoadScene(2);
    }
    public void QuitGame() {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
