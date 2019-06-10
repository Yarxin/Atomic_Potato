using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipsPool : MonoBehaviour
{
    public int chipsPoolSize = 3;
    public GameObject chipsPrefab;
    public float spawnRate = 9f;

    private GameObject[] chips;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceSpawned;
    private float spawnXPosition = 5f;
    private int currentChips = 0;

    // Start is called before the first frame update
    void Start()
    {
        chips = new GameObject[chipsPoolSize];
        for (int i = 0; i < chipsPoolSize; i++)
        {
            chips[i] = (GameObject)Instantiate(chipsPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceSpawned >= spawnRate)
        {
            timeSinceSpawned = 0;
            //float spawnYPosition = Random.Range(platformMin, platformMax);
            chips[currentChips].transform.position = new Vector2(spawnXPosition, -0.62f);
            currentChips++;
            if (currentChips >= chipsPoolSize)
            {
                Start();
                currentChips = 0;
            }
        }
    }
}
