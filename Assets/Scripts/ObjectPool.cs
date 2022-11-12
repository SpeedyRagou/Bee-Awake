using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] objects;
    
    // Start is called before the first frame update
    void Start()
    {
        Sprite[] all_bad = Resources.LoadAll<Sprite>("Assets/Sprites/SleeptDown");
        Sprite[] all_good = Resources.LoadAll<Sprite>("Assets/Sprites/WakeUps");
        Debug.Log(all_bad.Length);

        for (int i = 0; i < objects.Length; i++)
        {

            GameObject instance = Instantiate(objects[i], new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
            //instance.GetComponent<SpriteRenderer>().sprite = ;
            
            instance.transform.localPosition = new Vector3(0, 0, 0);
            instance.SetActive(false);
            objects[i] = instance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive())
        {
            spawnObject();
        }
    }

    bool isActive()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].activeSelf)
            {
                return true;
            }
        }

        return false;
    }

    GameObject spawnObject()
    {
        int index = Random.Range(0, objects.Length);

        objects[index].gameObject.SetActive(true);
        objects[index].transform.localPosition = new Vector3(0,0,0);
        objects[index].transform.rotation = Quaternion.identity;

        return objects[0];
    }
}
