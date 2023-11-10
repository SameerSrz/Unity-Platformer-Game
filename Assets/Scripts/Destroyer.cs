using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Crate"))
        {
            Destroy(collision.gameObject);
            //Destroy(gameObject);
        }
    }
}
