﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    [SerializeField] private int maxWeight;
    [SerializeField] private int currentWeight;
    public SumoWeight sumo;
    public PlayerController playerController;

    [SerializeField] private float invincibilityLength;
    private float invincibilityCounter;

    private bool isRespawning;
    private Vector3 respawnPoint;
    [SerializeField] private float respawnLength;

    [SerializeField] private static MeshRenderer playerRenderer;
    private float flashCounter;
    [SerializeField] private float flashLength = 0.1f;

    // Use this for initialization
    void Start ()
    {
        sumo = GetComponent<SumoWeight>();

        playerRenderer = GetComponent<MeshRenderer>();
        playerController = GetComponent<PlayerController>();
    }
	public static void SetPlayerRenderer(SumoWeight sw)
    {
        playerRenderer = sw.GetComponent<MeshRenderer>();
    }
	// Update is called once per frame
	void Update ()
    {
        Invulnerability();

    }
    private void Invulnerability()
    {
        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashCounter = flashLength;
            }
            if (invincibilityCounter <= 0)
            {
                playerRenderer.enabled = true;
            }
        }
    }
    public void Respawn(SumoWeight sumo)
    {
        //Out of Bounds or Blowfish
        if (!isRespawning)
        {
            HealthManager.SetPlayerRenderer(sumo);
            StartCoroutine(RespawnCo(sumo));
        }
    }

    public IEnumerator RespawnCo(SumoWeight sumo)
    {
        isRespawning = true;
        sumo.gameObject.SetActive(false);

        yield return new WaitForSeconds(respawnLength);
        isRespawning = false;

        sumo.gameObject.SetActive(true);
        sumo.transform.position = respawnPoint;
        //invul frames
        invincibilityCounter = invincibilityLength;
        playerRenderer.enabled = false;
        flashCounter = flashLength;
    }

    public void AddWeightToPlayer(int healAmount)
    {
        if (invincibilityCounter < 0)
        {
            currentWeight += healAmount;
            if (currentWeight > maxWeight)
            {
                currentWeight = maxWeight;
            }
        }
    }
    public void RemoveWeightFromPlayer(int damage)
    {
        if (invincibilityCounter < 0)
            currentWeight -= damage;
    }
    public void HurtPlayer(Vector3 direction)
    {
        if (invincibilityCounter <= 0)
        {
            playerController.Knockback(direction);
        }
    }
}
