﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SumoWeight : MonoBehaviour
{
    private float startingWeight = 100;
    [SerializeField]
    private float currentWeight;
    [SerializeField]
    private int maxLives = 3;
    [SerializeField]
    private int currentLives;

    private bool isDead;
    public Vector3 respawnPoint;

    private MeshRenderer playerRenderer;
    HealthManager healthManager;
    // Use this for initialization
    void Start ()
    {
        playerRenderer = GetComponent<MeshRenderer>();
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
        UpdatePlayerWeightText();
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
        Destroy(gameObject);
    }

}
