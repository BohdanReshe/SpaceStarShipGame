using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    private float spawnPosXRange = 17;
    private float spawnPosZ = 19;
    private float spawnInterval = 1.5f;
    private float spawnTimer = 0.0f;
    private float decreaseSpawnIntervalTimer = 0.0f;
    private float stepChangeSpawnInterval = 0.2f;
    private float timeToDecreaseSpawnRate = 15;
    private float possibileFastestSpawnIntervalLimit = 0.1f;

    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] GameObject heartPrefab;
    [SerializeField] Animator showAnimationMoreEnemiesText;
    [SerializeField] TextMeshProUGUI popUpSpawnRateText;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        InvokeRepeating("SpawnHeart", 10, 10);
    }

    private void Update()
    {
        // Spawn enemies with specific inteval
        spawnTimer += 1 * Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnRandomEnemy();
            spawnTimer = 0.0f;
        }

        decreaseSpawnIntervalTimer += 1 * Time.deltaTime;
        if (decreaseSpawnIntervalTimer >= timeToDecreaseSpawnRate)
        {
            if (spawnInterval >= possibileFastestSpawnIntervalLimit)
            {
                spawnInterval -= stepChangeSpawnInterval;
                decreaseSpawnIntervalTimer = 0.0f;
                showAnimationMoreEnemiesText.SetTrigger("ShowMoreEnemiesTrigger");
                popUpSpawnRateText.text = ("Spawn interval = " + spawnInterval.ToString("0.0") + " s");
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            SpawnRandomEnemy();
        }
    }

    void SpawnHeart()
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnPosXRange, spawnPosXRange), 0, spawnPosZ);
            Instantiate(heartPrefab, spawnPos, heartPrefab.transform.rotation);
        }

    public void SpawnRandomEnemy()
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnPosXRange, spawnPosXRange), 0, spawnPosZ);
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
 }