using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndless : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private Transform platformStart;
    private const float PlayerDistance=400f;
    private Vector3 LastPosition;
    [SerializeField] private PlayerMovement player;
    //public GameObject player;
    private void Awake()
    {
        if (GameManager.Instance.IsGameplay)
        {
            LastPosition = platformStart.Find("EndPosition").position;

            for (int i = 0; i < 25; i++)
            {
                SpawnPlatformPart();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameplay)
        {
            if (Vector3.Distance(player.transform.position, LastPosition) < PlayerDistance)
            {
                SpawnPlatformPart();
            }
        }
    }
    private void SpawnPlatformPart()
    {
        Transform lastSpawnPosition = SpawnPlatform(LastPosition);
        LastPosition = lastSpawnPosition.Find("EndPosition").position;
    }
    Transform SpawnPlatform(Vector2 spawnPos)
    {
        Transform platformPartTransform = Instantiate(platform.transform, new Vector3(spawnPos.x, -3.99f, 0), Quaternion.identity);
        return platformPartTransform;
    }
}
