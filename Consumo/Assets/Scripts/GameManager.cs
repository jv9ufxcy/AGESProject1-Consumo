using System.Collections;
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
    //replace spawnpoint with array
    //for(int i = 0; i < players.length; i++)
    //player[i].transform.position = playerSpawnPoint[i].position

    //private TankManager GetRoundWinner()
    //{
    //    // Go through all the sumos...
    //    for (int i = 0; i < m_Tanks.Length; i++)
    //    {
    //        // ... and if one of them is active, it is the winner so return it.
    //        if (m_Tanks[i].m_Instance.activeSelf)
    //            return m_Tanks[i];
    //    }

    //    // If none of the tanks are active it is a draw so return null.
    //    return null;
    //}
}
