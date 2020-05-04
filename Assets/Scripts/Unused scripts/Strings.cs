using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strings : MonoBehaviour
{
    public string playerName = "Dio";
    public bool isFinished = false;
    public int highscore = 0;
    public float Volume = 0.5f;

    public void SavePrefs()
    {
       // GameData gameD = new GameData();


        PlayerPrefs.SetString("PlayerName", playerName);
        //PlayerPrefs.SetString("Player2Name", "playerplayer"); name for player 2
        PlayerPrefs.SetInt("Highscore", highscore);
        PlayerPrefs.SetFloat("Sound", Volume);
    }
    public void LoadPrefs()
    {
        playerName = PlayerPrefs.GetString("PlayerName");
        highscore = PlayerPrefs.GetInt("Highscore");
        Volume = PlayerPrefs.GetFloat("Sound");
    }
    // Start is called before the first frame update
    void Start()
    {
       // PlayerPrefs.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
