using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentWeight;
    public Text weightText;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

    public void AddWeight(int weightToAdd)
    {
        currentWeight += weightToAdd;
        weightText.text = "Global Weight: " + currentWeight;
    }
}
