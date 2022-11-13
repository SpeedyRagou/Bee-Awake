using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class SetUpLeaderBoard : MonoBehaviour
{

    public GameObject leaderboard_entry;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            string lines = File.ReadAllText("./data.txt");

            GameObject leaderBord = GameObject.Find("Main Camera/Canvas/ScoreBoard");
            leaderBord.GetComponent<TextMeshPro>().text = "Hier dein Stuff";
        }catch
        {
            Debug.Log("No File Found");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
