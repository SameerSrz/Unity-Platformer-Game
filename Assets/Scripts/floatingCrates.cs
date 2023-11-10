using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingCrates : MonoBehaviour
{
    public GameObject SpawnPoint;
    public GameObject Crates;
    public float Timer;
    public float TimeBetweenSpawn;
    // Start is called before the first frame update
    private void Awake()
    {
        /*GetComponent<Collider2D>().isTrigger = true;*/
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameplay)
        {
            Timer += Time.deltaTime;
            if (Timer > TimeBetweenSpawn) 
            {
                Timer = 0;
                int RandNum = Random.Range(0, 4);
                print(RandNum = Random.Range(0, 4));
                GameObject temp = Instantiate(Crates, SpawnPoint.transform.position, Quaternion.identity);
                temp.transform.position = new Vector3(temp.transform.position.x, -2.56f, -26.7f);
            }
        }
    }
    
}
