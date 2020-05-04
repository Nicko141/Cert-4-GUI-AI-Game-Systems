using UnityEngine;
using UnityEngine.UI;
public class PlayerSaveAndLoad : MonoBehaviour
{
    public PlayerMovement player;
    private CharacterController controller;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        if (player != null)
        {
            controller = player.GetComponent<CharacterController>();
        }
        if (!PlayerPrefs.HasKey("Loaded"))
        {
            PlayerPrefs.DeleteAll();
            //first load function... set up character data
            FirstLoad();
            //save data... makes first save file in binary
            Save();
            //now have 1st save file
            PlayerPrefs.SetInt("Loaded", 0);
        }
        else
        {
            Load();
        }
    }
    public void FirstLoad()
    {

    }

    public void Save()
    {
        //do when binary is done
        PlayerBinary.SavePlayerData(player);
    }
    public void Load()
    {
        controller.enabled = false;
        //do when binary is done
        PlayerData data = PlayerBinary.LoadPlayerData(player);
        player.transform.position = new Vector3(data.pX, data.pY, data.pZ);
        controller.enabled = true;

    }
}
