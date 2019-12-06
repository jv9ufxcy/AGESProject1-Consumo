using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SumoWeight : MonoBehaviour
{

    public static event Action<int> SumoDied;

    [SerializeField] private float startingHealth = 100, sizeLevel, levelExp, levelCap=100, currentHealth;
    [SerializeField] private int maxLives = 3, currentLives;

    private bool isDead;
    public Vector3 respawnPoint;
    public int playerNumber;

    private Transform playerSize;
    private Collider playerCollision;
    private MeshRenderer playerRenderer;
    HealthManager healthManager;
    // Use this for initialization
    void Start ()
    {
        Initialize();
        CheckSCene();
        SetStartingStats();
    }

    private void SetStartingStats()
    {
        respawnPoint = transform.position;
        currentHealth = startingHealth;
        currentLives = maxLives;
        isDead = false;
    }

    private void Initialize()
    {
        playerSize = GetComponent<Transform>();
        playerRenderer = GetComponent<MeshRenderer>();
        playerCollision = GetComponent<Collider>();
    }

    private void CheckSCene()
    {
        if (SceneManager.GetActiveScene().name == "mainscene")
            healthManager = GameObject.Find("GameManager").GetComponent<HealthManager>();
    }

    public void AddHealthToPlayer(float healAmount)
    {
        currentHealth += healAmount;
        levelExp += healAmount;
    }
    public void RemoveHealthFromPlayer(float damage)
    {
        currentHealth -= damage;
        levelExp -= damage;
    }
    // Update is called once per frame
    private void Update()
    {
        LevelUp();
    }

    private void LevelUp()
    {
        while (levelExp>=levelCap)
        {
            sizeLevel++;
            levelExp -= levelCap;
        }
        playerSize.localScale = new Vector3(1f, 1f, 1f) * ((sizeLevel / 5f)+1f);

        if (levelExp<0)
        {
            levelExp = 0;
            KillPlayer();
        }
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
        this.gameObject.SetActive(false);
      //  Destroy(gameObject);
    }

}
