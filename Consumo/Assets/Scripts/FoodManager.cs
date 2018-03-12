using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField]    private GameObject foodPrefab;
    [SerializeField]    private Vector3[] spawnPoints;

    [SerializeField]    private float foodSpawnInterval = 5f;
    [SerializeField]    private float foodSpawnTimer = 0f;

    void Update()
    {
        foodSpawnTimer += Time.deltaTime;

        if (foodSpawnTimer >= foodSpawnInterval)
        {
            foodSpawnTimer -= foodSpawnInterval;
            SpawnFood(foodPrefab, 1);
        }
    }

    public void SpawnFood(GameObject foodToSpawn, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject foodInstance = Instantiate(foodToSpawn, spawnPosition, Quaternion.identity);
            //foodscript newfood = foodinstance.GetComponent<foodscript>();
            //newfood.foodvalue *= 1 + players[0].sizebonus + players[1].sizebonus;
            //can also access food's rigidbody and add velocity to it
        }
    }
}
