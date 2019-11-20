﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public int scoreValue = 10;

    private GameController gameControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if(gameControllerObject != null)
        {
            // I got the game controller object!
            gameControllerScript = gameControllerObject.GetComponent<GameController>();

            if(gameControllerScript == null)
            {
                // There is no GameController script on my game controller object
                Debug.Log("Cannot find GameController script on GameController object");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Instantiate an explosion and position it
        Instantiate(explosion, this.transform.position, this.transform.rotation);

        if(other.gameObject.CompareTag("Player"))
        {
            // Collided with the player object
            gameControllerScript.GameOver();
        }
        else
        {
            // Increase the score
            gameControllerScript.AddScore(scoreValue);
        }

        Destroy(other.gameObject); // "Laser" or ship or anything with a collider
        Destroy(this.gameObject); // Asteroid
    }
}
