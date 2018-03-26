using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoiledFoodPickup : MonoBehaviour
{
    [SerializeField] private float lifeTime = 10f;
    public int value;
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
            FindObjectOfType<GameManager>().RemoveWeight(value);
            SumoWeight sumoWeight = other.gameObject.GetComponent<SumoWeight>();
            if (sumoWeight != null)
            {
                sumoWeight.RemoveWeightFromPlayer(value);
            }
            Destroy(gameObject);
        }
    }
}
