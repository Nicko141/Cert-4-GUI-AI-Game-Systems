using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAIHealth : MonoBehaviour
{
    AIStateMachine1 AI;
    Text AItext;
    // Start is called before the first frame update
    void Start()
    {
        AI = FindObjectOfType<AIStateMachine1>();
        AItext = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        AItext.text = AI.AIHealth.ToString();
    }
}
