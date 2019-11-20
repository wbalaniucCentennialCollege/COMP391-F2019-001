using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Variables that control spawining waves
    [Header("Wave Settings")]
    public GameObject hazard;   // What are we spawning?
    public Vector2 spawnValue;  // Where are we spawning it?
    public int hazardCount;     // How many are we spawning per wave?

    [Header("Wave Time Settings")]
    public float startWait;     // How long until the first wave?
    public float spawnWait;     // How long between each hazard in a wave?
    public float waveWait;      // How long between waves of hazards?

    [Header("UI Settings")]
    public Text scoreText;
    public Text gameOverText;
    public Text restartText;

    private int score = 0;
    private bool gameOver, restart;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = restart = false;
        UpdateScore();
        StartCoroutine(SpawnWaves());   // Start my spawn waves coroutine.
    }

    // Update is called once per frame
    void Update()
    {
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                // Restart our game (3 methods) 
                // The old way. Do not use.
                // Application.LoadLevel("Game");
                // The new way
                // SceneManager.LoadScene("Game");
                // Reload the same scene. Everytime. Guaranteed.
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    // Coroutine to spawn waves of hazards
    IEnumerator SpawnWaves()
    {
        // Initial delay before my first wave
        yield return new WaitForSeconds(startWait); // Pause for "startWait" seconds

        while(true)
        {
            // Spawning some hazards
            for(int i = 0; i < hazardCount; i++)
            {
                // Spawn a single hazard
                Vector2 spawnPosition = new Vector2(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y));

                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait); // Wait for the next asteroid.
            }
            yield return new WaitForSeconds(waveWait); // Wait for the next wave

            if(gameOver)
            {
                restartText.gameObject.SetActive(true);
                restart = true;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue; // score = score + newScoreValue;
        // Debug.Log("Score: " + score);
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
    }
}
