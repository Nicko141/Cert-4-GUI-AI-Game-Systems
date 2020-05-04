using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string testString = "Hello";
        switch(testString)
        {
            case "Jump":
                //do something
                break;
            case "Hello":
                //do somethimg
                break;
            default: //if it is none of the above
                //do something
                break;
        }
        
        

                
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Space))
        {
            int attack = Random.Range(1,7);
            switch(attack)
            {
            case 1:
                Debug.Log ("dice roll 1 - You missed! How could you miss? He was 3 feet in front of you!!");
                break;
            case 2:
                Debug.Log("dice roll 2 - did?...did you even do anything?");
                break;
            case 3:
                Debug.Log("dice roll 3 - you hit him, good, great, no no thats really great");
                break;
            case 4:
                Debug.Log("dice roll 4 - finally, some real damage");
                break;
            case 5:
                Debug.Log("dice roll 5 - alright!, thats what im talking about!");
                break;
            case 6:
                Debug.Log("dice roll 6 - he ded");
                break;
            }

        }
        
    }
}
