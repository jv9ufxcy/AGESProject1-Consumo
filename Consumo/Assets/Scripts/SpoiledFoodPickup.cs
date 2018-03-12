using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoiledFoodPickup : MonoBehaviour
{
    public int value;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().RemoveWeight(value);
            Destroy(gameObject);
        }
    }
}
