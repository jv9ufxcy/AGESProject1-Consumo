using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    [SerializeField] private int maxWeight;
    [SerializeField] private int currentWeight;

    //public int maxLives=3;
    //public int currentLives;

    public PlayerController playerController;

    [SerializeField] private float invincibilityLength;
    private float invincibilityCounter;

    private bool isRespawning;
    private Vector3 respawnPoint;
    [SerializeField] private float respawnLength;

    [SerializeField] private Renderer playerRenderer;
    private float flashCounter;
    [SerializeField] private float flashLength = 0.1f;
    // Use this for initialization
    void Start ()
    {
        //currentLives = maxLives;
        //currentWeight = maxWeight;
        respawnPoint = playerController.transform.position;
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
    public void Respawn()
    {
        //Out of Bounds or Blowfish
        if (!isRespawning)
        {
            StartCoroutine("RespawnCo");
        }
    }

    public IEnumerator RespawnCo()
    {
        isRespawning = true;
        playerController.gameObject.SetActive(false);

        yield return new WaitForSeconds(respawnLength);
        isRespawning = false;

        playerController.gameObject.SetActive(true);
        playerController.transform.position = respawnPoint;

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
