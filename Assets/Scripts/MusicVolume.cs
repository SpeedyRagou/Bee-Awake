using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public Slider MusicSlider;
    public Slider EffectsSlider;

    private List<string> musicVolume = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        readFile();
        if (musicVolume.Count > 0)
        {
            MusicSlider.value = float.Parse(musicVolume[0]);
            EffectsSlider.value = float.Parse(musicVolume[1]);
        }
        else
        {
            musicVolume.Add(MusicSlider.value.ToString());
            musicVolume.Add(EffectsSlider.value.ToString());

            writeFile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(MusicSlider.value != float.Parse(musicVolume[0]))
        {
            musicVolume[0] = MusicSlider.value.ToString();
            writeFile();
        }
        if (EffectsSlider.value != float.Parse(musicVolume[1]))
        {
            musicVolume[1] = EffectsSlider.value.ToString();
            writeFile();
        }
        //float musicVolume = MusicSlider.value;

        //File.WriteAllLines("./voulme.txt",)


        //AudioSource.volume = MusicSlider.value;
        //EffectSource.volume = .value;

    }

    void writeFile()
    {
        File.WriteAllLines("./voulme.txt", musicVolume.ToArray());
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
