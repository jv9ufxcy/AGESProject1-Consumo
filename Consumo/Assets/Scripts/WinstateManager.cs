using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinstateManager : MonoBehaviour
{
    [SerializeField]    private GameObject consumoCredits;
    [SerializeField]    private Text playerWin;
    private bool isGameOver = false;
    private int totalDeaths = 0;

    private void Start()
    {
        consumoCredits.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (isGameOver==true)
        {
            if (Input.GetButtonDown("Submit"))
            {
                Debug.Log("you pressed submit");
                SceneManager.LoadScene("joinscene");
            }
        }
    }
    // event handler
    private void OnSumoDied(int controllingPlayerNumber)
    {
        totalDeaths++;

        if (totalDeaths >= JoinPlayers.NumberOfJoinedPlayers - 1)
        {
            // Do your end game stuff here.
            Debug.Log("Player " + controllingPlayerNumber + " has won!");
            playerWin.text= ("Player " + controllingPlayerNumber + " has won!");
            consumoCredits.gameObject.SetActive(true);
            isGameOver = true;
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
