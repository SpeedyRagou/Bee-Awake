using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class setVolume : MonoBehaviour
{

    private List<string> musicVolume = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] MusicSources = GetComponents<AudioSource>();
        readFile();
        if (musicVolume.Count > 0)
        {
            MusicSources[0].volume = float.Parse(musicVolume[0]);
            MusicSources[1].volume = float.Parse(musicVolume[1]);
            MusicSources[2].volume = float.Parse(musicVolume[1]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void readFile()
    {
        if (File.Exists("./voulme.txt"))
        {
            var Lines = File.ReadAllLines("./voulme.txt");
            foreach (string line in Lines)
            {
                musicVolume.Add(line);
            }
        }
    }
}
