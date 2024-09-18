using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{   
    private CharacterMovement characterMovement;
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
            if (characterMovement != null)
            {
                characterMovement.StopMovement();
            }
        }
    }
}
