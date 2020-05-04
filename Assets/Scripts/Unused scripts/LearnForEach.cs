using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnForEach : MonoBehaviour
{
    public List<GameObject> otherlist;
    public List<GameObject> objectsInGame; //= new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
      

        //objectsInGame.Add(new GameObject());
       /* int loop = 0;
        while(loop < otherlist.Count)
        {
            GameObject GO = otherlist[loop];
            GO.SetActive(false);
            loop++;
        }

        for(int index = 0; index < otherlist.Count; index++)
        {
            GameObject GO = otherlist[index];
                GO.SetActive(false);
        }*/

        foreach(GameObject GO in otherlist)
        {
            objectsInGame.Add(GO);
            Debug.Log(GO);
            //GO.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
