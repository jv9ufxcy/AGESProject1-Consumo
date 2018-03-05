using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public PlayerController playerController;
	// Use this for initialization
	void Start ()
    {
        playerController = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void HurtPlayer(Vector3 direction)
    {
        playerController.Knockback(direction);
    }
}
