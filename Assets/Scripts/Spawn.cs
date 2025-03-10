using UnityEngine;

using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float spawnRate = 1f; // Spawn rate in seconds (e.g., 1 ball per second)
    [SerializeField] int numberBallsToSpawn = 10; // Number of balls to spawn per burst

    private float timer = 0f;
    private int ballsSpawnedThisBurst = 0;

    void Update()
    {
        if (ballPrefab == null)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnBalls();
            timer = 0f; // Reset the timer
        }
    }

    void SpawnBalls()
    {
        ballsSpawnedThisBurst = 0; // Reset the counter for this burst

        while (ballsSpawnedThisBurst < numberBallsToSpawn)
        {
            Instantiate(ballPrefab, transform.position, transform.rotation);
            ballsSpawnedThisBurst++;
        }
    }
}
