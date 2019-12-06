using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoodManager : MonoBehaviour
{
    [SerializeField]    private GameObject[] foodPrefab;
    [SerializeField]    private float launchForce;

    [SerializeField]    private Vector3[] bottomSpawnPoints;
    [SerializeField]    private float foodSpawnIntervalBottom = 5f;
    [SerializeField]    private float foodSpawnTimerBottom = 0f;

    [SerializeField]    private Vector3[] leftSpawnPoints;
    [SerializeField]    private float foodSpawnIntervalLeft = 5f;
    [SerializeField]    private float foodSpawnTimerLeft = 0f;

    [SerializeField] private Vector3[] topSpawnPoints;
    [SerializeField] private float foodSpawnIntervalTop = 5f;
    [SerializeField] private float foodSpawnTimerTop = 0f;

    [SerializeField] private Vector3[] rightSpawnPoints;
    [SerializeField] private float foodSpawnIntervalRight = 5f;
    [SerializeField] private float foodSpawnTimerRight = 0f;

    Rigidbody foodRB;
    private int randomInt;
    [SerializeField] private float minSizeMultiplier=1, maxSizeMultiplier=3, globalSize=1, randomFloatMultiplier;

    public float GlobalSize
    {
        get
        {
            return globalSize;
        }

        set
        {
            globalSize = value;
        }
    }

    private void Start()
    {

    }
    void Update()
    {
        IncreaseMultiplier();
        FoodSpawnTimers();
    }

    private void IncreaseMultiplier()
    {
        randomFloatMultiplier = UnityEngine.Random.Range(minSizeMultiplier, maxSizeMultiplier);
        if (GlobalSize % 100 == 0)
        {
            maxSizeMultiplier++;
        }
    }

    private void FoodSpawnTimers()
    {
        //bottom timer
        foodSpawnTimerBottom += Time.deltaTime;
        randomInt = UnityEngine.Random.Range(0, foodPrefab.Length);
        if (foodSpawnTimerBottom >= foodSpawnIntervalBottom)
        {
            foodSpawnTimerBottom -= foodSpawnIntervalBottom;
            SpawnFoodBottom(foodPrefab[randomInt], 1);
        }
        //left timer
        foodSpawnTimerLeft += Time.deltaTime;
        if (foodSpawnTimerLeft >= foodSpawnIntervalLeft)
        {
            foodSpawnTimerLeft -= foodSpawnIntervalLeft;
            SpawnFoodLeft(foodPrefab[randomInt], 1);
        }
        //top timer
        foodSpawnTimerTop += Time.deltaTime;
        if (foodSpawnTimerTop >= foodSpawnIntervalTop)
        {
            foodSpawnTimerTop -= foodSpawnIntervalTop;
            SpawnFoodTop(foodPrefab[randomInt], 1);
        }
        //right timer
        foodSpawnTimerRight += Time.deltaTime;
        if (foodSpawnTimerRight >= foodSpawnIntervalRight)
        {
            foodSpawnTimerRight -= foodSpawnIntervalRight;
            SpawnFoodRight(foodPrefab[randomInt], 1);
        }
    }

    //foodscript newfood = foodinstance.GetComponent<foodscript>();
    //newfood.foodvalue *= 1 + players[0].sizebonus + players[1].sizebonus;
    //can also access food's rigidbody and add velocity to it
    public void SpawnFoodBottom(GameObject foodToSpawn, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPosition = bottomSpawnPoints[UnityEngine.Random.Range(0, bottomSpawnPoints.Length)];
            GameObject foodInstance = Instantiate(foodToSpawn, spawnPosition, Quaternion.identity);
            foodInstance.GetComponent<FoodPickup>().CalculateSize(GlobalSize);
            foodRB = foodInstance.GetComponent<Rigidbody>();
            foodRB.velocity = foodRB.transform.forward * launchForce;

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
    public void SpawnFoodTop(GameObject foodToSpawn, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPosition = topSpawnPoints[UnityEngine.Random.Range(0, topSpawnPoints.Length)];
            GameObject foodInstance = Instantiate(foodToSpawn, spawnPosition, Quaternion.identity);
            foodRB = foodInstance.GetComponent<Rigidbody>();
            foodRB.velocity = -foodRB.transform.forward * launchForce;

        }
    }
    public void SpawnFoodRight(GameObject foodToSpawn, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPosition = rightSpawnPoints[UnityEngine.Random.Range(0, leftSpawnPoints.Length)];
            GameObject foodInstance = Instantiate(foodToSpawn, spawnPosition, Quaternion.identity);
            foodRB = foodInstance.GetComponent<Rigidbody>();
            foodRB.velocity = -foodRB.transform.right * launchForce;
        }
    }
    public void AddSize(float sizeToAdd)
    {
        globalSize += sizeToAdd;
        //weightText.text = "Global Weight: " + globalWeight;
    }

    public void RemoveSize(float sizeToRemove)
    {
        globalSize -= sizeToRemove;
        //weightText.text = "Global Weight: " + globalWeight;
    }
}
