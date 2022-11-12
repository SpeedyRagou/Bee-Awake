using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingStrength : MonoBehaviour
{

    private Sprite[] loadingStates;
    private GameObject observable;

    // Start is called before the first frame update
    void Start()
    {
        loadingStates = Resources.LoadAll<Sprite>("Ladebalken");
        observable = GameObject.Find("Main Camera/player/arm");
    }

    // Update is called once per frame
    void Update()
    {
        Sprite newState = loadingStates[(int) Mathf.Round(observable.GetComponent<CharacterControl>().power)];
        gameObject.GetComponent<SpriteRenderer>().sprite = newState;
    }
}
