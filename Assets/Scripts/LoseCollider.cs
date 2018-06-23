using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
    private LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();

        Debug.Log("trigger");
        levelManager.LoadLevel("Game Over");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collide");
        
    }
}
