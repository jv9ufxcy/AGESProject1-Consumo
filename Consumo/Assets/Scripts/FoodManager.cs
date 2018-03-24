using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField]    private GameObject[] foodPrefab;
    [SerializeField]    private Vector3[] bottomSpawnPoints;
    [SerializeField]    private Vector3[] leftSpawnPoints;
    [SerializeField]    private float launchForce;
    [SerializeField]    private float foodSpawnIntervalBottom = 5f;
    [SerializeField]    private float foodSpawnTimerBottom = 0f;
    [SerializeField]    private float foodSpawnIntervalLeft = 5f;
    [SerializeField]    private float foodSpawnTimerLeft = 0f;

    Rigidbody foodRB;
    private int randomInt;

    private void Start()
    {
        //foodRB = AddComponent<Rigidbody>();
    }


    void Update()
    {

        foodSpawnTimerBottom += Time.deltaTime;
        randomInt=UnityEngine.Random.Range(0, foodPrefab.Length);
        if (foodSpawnTimerBottom >= foodSpawnIntervalBottom)
        {
            foodSpawnTimerBottom -= foodSpawnIntervalBottom;
            SpawnFoodBottom(foodPrefab[randomInt], 1);
        }
        foodSpawnTimerLeft += Time.deltaTime;
        if (foodSpawnTimerLeft >= foodSpawnIntervalLeft)
        {
            foodSpawnTimerLeft -= foodSpawnIntervalLeft;
            SpawnFoodLeft(foodPrefab[randomInt], 1);
        }
    }

    public void SpawnFoodBottom(GameObject foodToSpawn, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPosition = bottomSpawnPoints[UnityEngine.Random.Range(0, bottomSpawnPoints.Length)];
            GameObject foodInstance = Instantiate(foodToSpawn, spawnPosition, Quaternion.identity);
            foodRB = foodInstance.GetComponent<Rigidbody>();
            foodRB.velocity = foodRB.transform.forward * launchForce;

            //foodscript newfood = foodinstance.GetComponent<foodscript>();
            //newfood.foodvalue *= 1 + players[0].sizebonus + players[1].sizebonus;
            //can also access food's rigidbody and add velocity to it
        }
    }
    public void SpawnFoodLeft(GameObject foodToSpawn, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPosition = leftSpawnPoints[UnityEngine.Random.Range(0, leftSpawnPoints.Length)];
            GameObject foodInstance = Instantiate(foodToSpawn, spawnPosition, Quaternion.identity);
            foodRB = foodInstance.GetComponent<Rigidbody>();
            foodRB.velocity = foodRB.transform.right * launchForce;
        }
    }
}
