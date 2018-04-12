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

    [SerializeField] private Color p1Color, p2Color, p3Color, p4Color;

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
            if (player.IsJoined)
            {
                SpawnPlayerControlledCharacter(player);
            }
            
        }
    }
    //void SetupColor(Player controllingPlayer)
    //{
    //    m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(playerColor) + ">PLAYER " + controllingPlayer.PlayerNumber + "</color>";
    //    MeshRenderer[] renderers = playerCharacterPrefab.GetComponentsInChildren<MeshRenderer>();

    //    for (int i = 0; i < renderers.Length; i++)
    //    {
    //        renderers[i].material.color = playerColor;
    //    }
    //}
    // Update is called once per frame
    void Update()
    {

    }
    private void SpawnPlayerControlledCharacter(Player controllingPlayer)
    {
        GameObject playerCharacterGameObject = Instantiate(playerCharacterPrefab);
        var playerCharacter = playerCharacterGameObject.GetComponent<PlayerController>();
        playerCharacter.ControllingPlayer = controllingPlayer;
        var sumoWeight = playerCharacterGameObject.GetComponent<SumoWeight>();
        sumoWeight.playerNumber = controllingPlayer.PlayerNumber;
        var sumoRenderer = playerCharacterGameObject.GetComponent<MeshRenderer>();

        //playerCharacter.ControllingPlayer.SpawnedCount = playerCharacter.ControllingPlayer.SpawnedCount++;
        switch (controllingPlayer.PlayerNumber)
        {
            case 1:
                playerCharacterGameObject.transform.position = player1SpawnPoint.position;
                MeshRenderer p1Renderer = playerCharacterGameObject.GetComponentInChildren<MeshRenderer>();
                p1Renderer.material.color = p1Color;
                break;

            case 2:
                playerCharacterGameObject.transform.position = player2SpawnPoint.position;
                MeshRenderer p2Renderer = playerCharacterGameObject.GetComponentInChildren<MeshRenderer>();
                p2Renderer.material.color = p2Color;
                break;

            case 3:
                playerCharacterGameObject.transform.position = player3SpawnPoint.position;
                MeshRenderer p3Renderer = playerCharacterGameObject.GetComponentInChildren<MeshRenderer>();
                p3Renderer.material.color = p3Color;
                break;

            case 4:
                playerCharacterGameObject.transform.position = player4SpawnPoint.position;
                MeshRenderer p4Renderer = playerCharacterGameObject.GetComponentInChildren<MeshRenderer>();
                p4Renderer.material.color = p4Color;

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
