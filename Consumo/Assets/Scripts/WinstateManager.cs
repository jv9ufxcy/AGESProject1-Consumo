using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinstateManager : MonoBehaviour
{
    private int totalDeaths = 0;


    // event handler
    private void OnSumoDied(int controllingPlayerNumber)
    {
        totalDeaths++;

        if (totalDeaths >= JoinPlayers.NumberOfJoinedPlayers - 1)
        {
            // Do your end game stuff here.
            Debug.Log("Player " + controllingPlayerNumber + " has won!");
        }
    }

    private void OnEnable()
    {
        SumoWeight.SumoDied += OnSumoDied;
    }

    private void OnDisable()
    {
        SumoWeight.SumoDied -= OnSumoDied;
    }

}
