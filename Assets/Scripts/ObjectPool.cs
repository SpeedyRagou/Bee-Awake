using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] objects;
    public int spawnHeight;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            GameObject instance = Instantiate(objects[i], new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
            instance.transform.localPosition = new Vector3(0, 0, 0);
            instance.SetActive(false);
            objects[i] = instance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnObject();
    }

    GameObject spawnObject()
    {
        int index = Random.Range(0, objects.Length);

        objects[index].gameObject.SetActive(true);
        objects[index].transform.localPosition = new Vector3(-7,spawnHeight, 0);

        return objects[0];
    }
}
