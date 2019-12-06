using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPickup : MonoBehaviour
{
    private enum FoodType {healthy, spoiled, deadly};
    [SerializeField] private FoodType _foodType;
    [SerializeField] private float lifeTime = 10f;
    public float value;
    private void Update()
    {
        LifeTime();
    }
    public void CalculateSize(float sizeValue)
    {
        sizeValue *= .10f;
        transform.localScale = new Vector3(1, 1, 1) * (sizeValue+1f);
        value += sizeValue;
    }
    private void LifeTime()
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
        if (other.CompareTag("Player"))
        {
            
            SumoWeight sumoWeight = other.gameObject.GetComponent<SumoWeight>();
            if (sumoWeight != null)
            {
                switch (_foodType)
                {
                    case FoodType.healthy:
                        sumoWeight.AddHealthToPlayer(value);
                        FindObjectOfType<FoodManager>().AddSize(value);
                        break;
                    case FoodType.spoiled:
                        sumoWeight.RemoveHealthFromPlayer(value);
                        FindObjectOfType<FoodManager>().RemoveSize(value);
                        break;
                    case FoodType.deadly:
                        sumoWeight.KillPlayer();
                        break;
                    default:
                        break;
                }
                
            }
            Destroy(gameObject);
        }
    }
}
