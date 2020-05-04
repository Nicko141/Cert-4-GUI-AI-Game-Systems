using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int Score;
    public string PlayerName;
    public float TimePlayed;
    public GameData(int scoreInt, string nameStr, float timePlayedF)
    {
        Score = scoreInt;
        PlayerName = nameStr;
        TimePlayed = timePlayedF;
    }
}
