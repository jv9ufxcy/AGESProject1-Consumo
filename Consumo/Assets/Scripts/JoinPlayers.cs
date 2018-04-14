using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JoinPlayers : MonoBehaviour
{
    #region Serialized fields
    [SerializeField]
    private Text player1Ready, player2Ready, player3Ready, player4Ready, player1Start;
    [SerializeField]
    private Transform player1SpawnPoint, player2SpawnPoint,
        player3SpawnPoint, player4SpawnPoint;
    [SerializeField]
    GameObject playerCharacterPrefab, playerCredits;
    #endregion
    #region cosntants
    public const int MaxPlayers = 4;
    #endregion

    #region static fields and properties
    public static int NumberOfJoinedPlayers
    {
        get
        {
            return allPlayers.Where(player => player.IsJoined).Count();
        }
    }
    public static List<Player> AllPlayers
    {
        get { return allPlayers; }
    }

    private static List<Player> allPlayers;
    #endregion

    #region private fields
    private string joinButtonName = "Fire";
    #endregion

    #region Monobehaviour functions
    // Use this for initialization
    void Start ()
	{
        player1Start.gameObject.SetActive(false);
        playerCredits.gameObject.SetActive(false);

        InitializePlayerList();
    }
    bool IsVisible
    {
        get { return playerCredits.activeSelf; }
    }
    // Update is called once per frame
    void Update ()
	{
        if (allPlayers[0].IsJoined)
        {
            if (Input.GetButtonDown("Submit"))
            {
                SceneManager.LoadScene("mainscene");
            }
            if (Input.GetButtonDown("Select"))
            {
                if (IsVisible)
                {
                    playerCredits.SetActive(false);
                }
                else
                {
                    playerCredits.SetActive(true);
                }
            }
        }
        CheckForJoiningPlayers();
    }
    private void CheckForJoiningPlayers()
    {
        var unjoinedPlayers = allPlayers.Where(player => !player.IsJoined);

        foreach (var player in unjoinedPlayers)
        {
            Debug.Log("Check Player " + player.PlayerNumber.ToString());
            if (Input.GetButtonDown(joinButtonName + player.PlayerNumber.ToString()))
            {
                Debug.Log("Join player " + player.PlayerNumber);
                player.IsJoined = true;
                SpawnPlayerControlledCharacter(player);
            }
        }
    }
    #endregion
    private void SpawnPlayerControlledCharacter(Player controllingPlayer)
    {
        GameObject playerCharacterGameObject = Instantiate(playerCharacterPrefab);
        var playerCharacter = playerCharacterGameObject.GetComponent<PlayerController>();
        playerCharacter.ControllingPlayer = controllingPlayer;

        switch (controllingPlayer.PlayerNumber)
        {
            case 1:
                playerCharacterGameObject.transform.position = player1SpawnPoint.position;
                player1Ready.text = "Player 1 Ready";
                player1Start.gameObject.SetActive(true);
                break;

            case 2:
                playerCharacterGameObject.transform.position = player2SpawnPoint.position;
                player2Ready.text = "Player 2 Ready";
                break;

            case 3:
                playerCharacterGameObject.transform.position = player3SpawnPoint.position;
                player3Ready.text = "Player 3 Ready";
                break;

            case 4:
                playerCharacterGameObject.transform.position = player4SpawnPoint.position;
                player4Ready.text = "Player 4 Ready";
                break;
            default:
                throw new System.Exception("Invalid player number.");
        }
    }
    public static void InitializePlayerList()
    {
        allPlayers = new List<Player>();

        for (int i = 1; i <= MaxPlayers; i++)
        {
            var player = new Player(i);
            allPlayers.Add(player);
        }
    }
}
