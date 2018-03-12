using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SumoWeight sumoWeight = other.gameObject.GetComponent<SumoWeight>();
            if (sumoWeight != null)
            {
                sumoWeight.KillPlayer();
                Destroy(gameObject);
            }
        }
    }
}