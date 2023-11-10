using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameplay)
        {
            transform.position = new Vector3(player.transform.position.x+1.5f, transform.position.y, transform.position.z);
            
           
        }
    }
}
