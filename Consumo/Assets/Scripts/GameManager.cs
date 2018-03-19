﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentLives;
    public int globalWeight;
    public Text weightText;

    public void AddWeight(int weightToAdd)
    {
        globalWeight += weightToAdd;
        weightText.text = "Global Weight: " + globalWeight;
    }

    public void RemoveWeight(int weightToRemove)
    {
        globalWeight -= weightToRemove;
        weightText.text = "Global Weight: " + globalWeight;
    }
    public void RemoveLife(int lifeToRemove)
    {
        if (currentLives>0)
        {
            currentLives -= lifeToRemove;
        }
        
    }
}
