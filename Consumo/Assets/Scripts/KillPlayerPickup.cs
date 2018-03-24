using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerPickup : MonoBehaviour
{
    [SerializeField] private float lifeTime = 10f;
    private void Update()
    {
        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
        }
        else if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
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