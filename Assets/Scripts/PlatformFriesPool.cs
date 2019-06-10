using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFriesPool : MonoBehaviour
{
    public int platformPoolSize = 3;
    public GameObject platformPrefab;
    public float spawnRate = 9f;
    public float platformMin = -1.5f;
    public float platformMax = 2.25f;

    private GameObject[] platforms;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceSpawned;
    private float spawnXPosition = 10f;
    private int currentPlatform = 0;

    // Start is called before the first frame update
    void Start()
    {
        platforms = new GameObject[platformPoolSize];
        for (int i = 0; i < platformPoolSize; i++)
        {
            platforms[i] = (GameObject)Instantiate(platformPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceSpawned >= spawnRate)
        {
            timeSinceSpawned = 0;
            float spawnYPosition = Random.Range(platformMin, platformMax);
            platforms[currentPlatform].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentPlatform++;
            if (currentPlatform >= platformPoolSize)
            {
                Start();
                currentPlatform = 0;
            }
        }
    }
}
