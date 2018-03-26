using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    #region Serialized fields
    [SerializeField]
    private Transform player1SpawnPoint, player2SpawnPoint,
        player3SpawnPoint, player4SpawnPoint;
    [SerializeField]
    GameObject playerCharacterPrefab;
    #endregion
    // Use this for initialization
    void Start()
    {
        //if we're starting from mainscene create 4 players and skip joinscene
        if (JoinPlayers.AllPlayers == null)
        {
            JoinPlayers.InitializePlayerList();

            foreach (var player in JoinPlayers.AllPlayers)
            {
                player.IsJoined = true;
            }
        }
        foreach (var player in JoinPlayers.AllPlayers)
        {
            SpawnPlayerControlledCharacter(player);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SpawnPlayerControlledCharacter(Player controllingPlayer)
    {
        GameObject playerCharacterGameObject = Instantiate(playerCharacterPrefab);
        var playerCharacter = playerCharacterGameObject.GetComponent<PlayerController>();
        playerCharacter.ControllingPlayer = controllingPlayer;
        playerCharacter.ControllingPlayer.SpawnedCount = playerCharacter.ControllingPlayer.SpawnedCount++;
        switch (controllingPlayer.PlayerNumber)
        {
            case 1:
                playerCharacterGameObject.transform.position = player1SpawnPoint.position;
                break;

            case 2:
                playerCharacterGameObject.transform.position = player2SpawnPoint.position;
                break;

            case 3:
                playerCharacterGameObject.transform.position = player3SpawnPoint.position;
                break;

            case 4:
                playerCharacterGameObject.transform.position = player4SpawnPoint.position;

                break;
            default:
                throw new System.Exception("Invalid player number.");
        }
    }
    //private void IfGameShouldEnd(Player controllingPlayer)
    //{
    //    switch (controllingPlayer.PlayerNumber)
    //    {
    //        case 1:
    //            if (controllingPlayer.SpawnedCount > 3)
    //                return true;
    //        default:
    //            return false;
    //    }
    //}
}
