using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBinds : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode UpKey = KeyCode.W;
    public KeyCode DownKey = KeyCode.S;
    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode DisableKey = KeyCode.T;
    bool isWaiting = false;
    public GameObject disableThis;
    string WhichKey;

    void OnGUI()
    {
        if(isWaiting == true)
        {
            
            if(Event.current.isKey)
            {
                switch(WhichKey)
            {
                case "Up":
                        UpKey = Event.current.keyCode;
                        break;
                case "Down":
                        DownKey = Event.current.keyCode;
                        break;
                case "Left":
                        LeftKey = Event.current.keyCode;
                        break;
                case "Right":
                        RightKey = Event.current.keyCode;
                        break;
            }
                //DisableKey = Event.current.keyCode;
            isWaiting = false;

            }
            
        }
    }

    // Update is called once per frame
    public void WaitForKeyInput(string KeyChanging)
    {
        isWaiting = true;
        WhichKey = KeyChanging;
    }
    private void Update()
    {
        if(Input.GetKeyDown(DisableKey) && Time.timeScale > 0)
        {
            if(disableThis.activeSelf == true)
            {
                disableThis.SetActive(false);
            }
            else
            {
                disableThis.SetActive(true);
            }
        }
    }
}
