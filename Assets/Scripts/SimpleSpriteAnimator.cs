using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpriteAnimator : MonoBehaviour
{
    public Sprite[] Frames = new Sprite[0];

    public float duration = 0.5f;

    public bool loop = true;

    public bool destroyObject = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnEnable()
    {
        StartCoroutine(playAnimation());
    }

    protected IEnumerator playAnimation()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        do
        {
            for (int i = 0; i < Frames.Length; i++)
            {
                if (!enabled)
                {
                    break;
                }
                sr.sprite = Frames[i];
                yield return new WaitForSeconds(duration / Frames.Length);
            }
        } while (enabled && loop);

        if (destroyObject)
        {
            Destroy(gameObject);
        }
    }
}
