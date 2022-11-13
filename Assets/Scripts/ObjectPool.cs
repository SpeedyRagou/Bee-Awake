using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] objects;
    
    // Start is called before the first frame update
    void Start()
    {
        Sprite[] all_bad = Resources.LoadAll<Sprite>("SleeptDown");
        Sprite[] all_good = Resources.LoadAll<Sprite>("WakeUps");

        bool good = true;

        int index_good = 0;
        int index_bad = 0;
        for (int i = 0; i < objects.Length; i++)
        {

            GameObject instance = Instantiate(objects[i], new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
            if (good)
            {
                instance.GetComponent<SpriteRenderer>().sprite = all_good[index_good];
                instance.GetComponent<Object>().good = good;
                good = false;
                index_good++;
                if (index_good >= all_good.Length)
                {
                    index_good = 0;
                }
            }
            else
            {
                instance.GetComponent<SpriteRenderer>().sprite = all_bad[index_bad];
                instance.GetComponent<Object>().good = false; 
                good = true;
                index_bad++;
                if (index_bad >= all_bad.Length){
                    index_bad = 0;
                }
            }


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
