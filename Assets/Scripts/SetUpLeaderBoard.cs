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
            /*for (int i = 0; i < lines.Length; i++)
            {
                string[] tmp = lines[i].Split(' ');
                GameObject new_Entry = Instantiate(leaderboard_entry, gameObject.transform);
                TextMeshPro[] all_infos = new_Entry.GetComponentsInChildren<TextMeshPro>();


                all_infos[0].text = i.ToString() + "#";
                all_infos[1].text = tmp[0];
                all_infos[2].text = tmp[1];

            }*/
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
