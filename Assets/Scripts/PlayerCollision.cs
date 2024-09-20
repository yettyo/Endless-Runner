using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{   
    private CharacterMovement characterMovement;
    public ScoreManager scoreManager;
    void Start() {
        characterMovement = GetComponent<CharacterMovement>();
        if(characterMovement == null)
        {
            Debug.LogError("CharacterMovement component not found on the player GameObject.");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Obstacle"))
        {
            Debug.Log("GameOver");
            CoinManager.Instance.SaveCoins();
            if (characterMovement != null)
            {
                characterMovement.StopMovement();
                scoreManager.SaveScore();
                SceneManager.LoadScene(2);
            }
        }
    }
}
