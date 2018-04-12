using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinstateManager : MonoBehaviour
{
    [SerializeField]
    private Text player1Start;
    private GameObject consumoCredits;
    private int totalDeaths = 0;

    private void Start()
    {
        player1Start.gameObject.SetActive(false);
    }

    // event handler
    private void OnSumoDied(int controllingPlayerNumber)
    {
        totalDeaths++;

        if (totalDeaths >= JoinPlayers.NumberOfJoinedPlayers - 1)
        {
            // Do your end game stuff here.
            Debug.Log("Player " + controllingPlayerNumber + " has won!");
            if (Input.GetButtonDown("Submit"))
            {
                SceneManager.LoadScene("joinscene");
            }
            if (Input.GetButtonDown("Submit"))
            {
                consumoCredits.gameObject.SetActive(true);
            }
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
