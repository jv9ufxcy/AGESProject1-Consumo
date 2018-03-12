using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	// Use this for initialization
	void Start ()
    {
        currentWeight = startingWeight;
        currentLives = maxLives;
        isDead = false;
	}
	
	// Update is called once per frame
	public void KillPlayer()
    {
        if (currentLives <= 0&&!isDead)
        {
            OnDeath();
        }
        else
        {
            FindObjectOfType<HealthManager>().Respawn();
            currentLives--;
        }
    }
    public void RespawnPlayer()
    {
            FindObjectOfType<HealthManager>().Respawn();
    }
    private void OnDeath()
    {
        isDead = true;
        gameObject.SetActive(false);
    }
}
