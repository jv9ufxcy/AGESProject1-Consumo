using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SumoWeight : MonoBehaviour
{

    public static event Action<int> SumoDied;

    private float startingWeight = 100;
    [SerializeField]
    private float currentWeight;
    [SerializeField]
    private int maxLives = 3;
    [SerializeField]
    private int currentLives;

    private bool isDead;
    public Vector3 respawnPoint;
    public int playerNumber;

    private CapsuleCollider playerCollision;
    private MeshRenderer playerRenderer;
    HealthManager healthManager;
    // Use this for initialization
    void Start ()
    {
        playerRenderer = GetComponent<MeshRenderer>();
        playerCollision = GetComponent<CapsuleCollider>();
        if (SceneManager.GetActiveScene().name == "mainscene")
            healthManager = GameObject.Find("GameManager").GetComponent<HealthManager>();
        respawnPoint = transform.position;
        currentWeight = startingWeight;
        currentLives = maxLives;
        isDead = false;
	}
    public void AddWeightToPlayer(int healAmount)
    {
            currentWeight += healAmount;
    }
    public void RemoveWeightFromPlayer(int damage)
    {
            currentWeight -= damage;
    }
    // Update is called once per frame
    private void Update()
    {
        //UpdatePlayerWeightText();
    }

    private void UpdatePlayerWeightText()
    {
        throw new NotImplementedException();
    }

    public void KillPlayer()
    {
        if (currentLives <= 0&&!isDead)
        {
            OnDeath();
        }
        else
        {
            healthManager.Respawn(this);
            currentLives--;
        }
    }
    public void RespawnPlayer()
    {
        healthManager.Respawn(this);
    }
    private void OnDeath()
    {
        isDead = true;


        // Raise the event
        if (SumoDied != null)
            SumoDied.Invoke(playerNumber);

      //  Destroy(gameObject);
    }

}
