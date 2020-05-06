using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;//Allows Serializable

public class KeyBindManager : MonoBehaviour
{
   
    //custom
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    //array of custom
    [Serializable]
    public struct KeyUISetup //creating a custom variable type of group variables
    {
        public string keyName;
        public Text keyDisplayText;
        public string defaultKey;
    }
    public KeyUISetup[] baseSetup;
    
    //public Text forward, backward, left, right;
    public GameObject currentKey;
    public Color32 changed = new Color32(39, 171, 249, 255);
    public Color32 selected = new Color32(239, 116, 36, 255);
    void Start()
    {//sets keys to player prefs
        //for loop to add keys to the dictionary
        if (baseSetup.Length == 0)
        {
            for (int i = 0; i < baseSetup.Length; i++)
            {
                //add key according to the save or default
                keys.Add(baseSetup[i].keyName, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(baseSetup[i].keyName, baseSetup[i].defaultKey)));
                //sets display text for keys
                baseSetup[i].keyDisplayText.text = keys[baseSetup[i].keyName].ToString();
            }
        }
        
        
       /* keys.Add("Forward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward","W")));
        keys.Add("Backward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));

        

        forward.text = keys["Forward"].ToString();
        backward.text = keys["Backward"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();*/
        
    }
    private void OnGUI()
    {

        if (currentKey != null)
        {

            string newKey = "";
            Event e = Event.current;
            if (e.isKey)
            {
                newKey = e.keyCode.ToString();
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                newKey = "LeftShift";
            }

            if (Input.GetKey(KeyCode.RightShift))
            {
                newKey = "RightShift";
            }

            if (newKey != "")
            {
                keys[currentKey.name] = (KeyCode)Enum.Parse(typeof(KeyCode), newKey);
                currentKey.GetComponentInChildren<Text>().text = newKey;
                currentKey.GetComponent<Image>().color = changed;
                currentKey = null;
            }
            
        }

    }
    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = selected;
        }
        
    }
    public void SaveKeys()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());

        }
        PlayerPrefs.Save();
    }

    void Update()
    {
        
    }
}
