using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int PlayerNumber { get; private set; }
    public bool IsJoined { get; set; }
    public int SpawnedCount { get; set; }

    public Player(int playerNumber, int spawnedCount=0)
    {
        PlayerNumber = playerNumber;
        SpawnedCount = spawnedCount;
    }
}
