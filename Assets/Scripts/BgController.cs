using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgController : MonoBehaviour
{
    [Range(-1f,1f)]
    public float scrollSpeed = 0.9f;
    float offSet;
    Material bg_Sky;
    // Start is called before the first frame update
    void Start()
    {
        bg_Sky = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameplay)
        {
            offSet += (Time.deltaTime * scrollSpeed / 10f);
            bg_Sky.SetTextureOffset("_MainTex", new Vector2(offSet, 0));
        }
    }
}
