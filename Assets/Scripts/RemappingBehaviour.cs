using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.UI;

public class RemappingBehaviour : MonoBehaviour
{
    public Button btn_changeRotate = default;
    public Button btn_changeCatch = default;

    // Start is called before the first frame update
    public KeyCode Rotate;
    public KeyCode Jump;



    void Start()
    {
        if (btn_changeRotate != null)
        {
            btn_changeRotate.onClick.AddListener(() => remapRotation());
        }
        if (btn_changeCatch != null)
        {
            btn_changeCatch.onClick.AddListener(() => remapCatch());
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (rotChanged)
        {
            Debug.Log("here");
            if (Input.anyKeyDown)
                Debug.Log(Input.anyKeyDown.ToString());
            rotChanged = false;
        }
        else if (chatchChanged)
        {

        }

    }

    bool rotChanged = false;

    void remapRotation()
    {

        rotChanged = true;

    }

    bool chatchChanged = false;
    void remapCatch()
    {

    }


    private void remapButton(string buttontag, string buttoncode)
    {
        //        Input.
    }
}
