using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;

public class SetUpLeaderBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists("./data.txt"))
        {
            string[] lines = File.ReadAllLines("./data.txt");

            GameObject leaderBoard = GameObject.Find("Main Camera/Canvas/ScoreBoard");

            string res = "";
            for (int i = 0; i < lines.Length; i++)
            {
                string newLine = (i + 1).ToString() + "# " + lines[i];
                res += newLine + "\n";
            }
            leaderBoard.GetComponent<TextMeshProUGUI>().SetText(res);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}

