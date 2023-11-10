using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    #region "SingleTon"
    public static ObstaclesController Instance;
    #endregion
    private Rigidbody2D Obstacle;
    public float speed = 5f;
    public GameObject SpawnPoint;
    public GameObject[] Obstacles;
    public GameObject PoisonBuble;
    public float Timer;
    public float Timer_2;
    public float TimeBetweenSpawn;
    public float TimeBetweenSpawnOfPoisonBubble;
    
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        //Obstacle = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameplay)
        {
            Timer += Time.deltaTime;
            if (Timer > TimeBetweenSpawn)
            {
                // Instantiates Crates And Obstacles
                Timer = 0;
                int RandNum = Random.Range(0, 3);
                print("obstacle" + RandNum);
                GameObject temp = Instantiate(Obstacles[RandNum], SpawnPoint.transform.position, Quaternion.identity);
                temp.transform.position = new Vector3(temp.transform.position.x, Obstacles[RandNum].transform.position.y, -26.7f);
               
            }
            Timer_2 += Time.deltaTime;
            if (Timer_2 > TimeBetweenSpawnOfPoisonBubble)
            {
                ///Posion Bubble Instatntiate

                Timer_2 = 0;
                GameObject temp_2 = Instantiate(PoisonBuble, SpawnPoint.transform.position, Quaternion.identity);
                temp_2.transform.position = new Vector3(temp_2.transform.position.x, temp_2.transform.position.y, -26.7f);
            }
           
        }

    }
}
