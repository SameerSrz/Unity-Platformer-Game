using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    #region "Singleton"
    public static enemyController Instance;
    #endregion
    private Rigidbody2D Enemy;
    public float EnemySpeed;
    private Animator anim;
    public float forwordSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        /*Enemy = GetComponent<Rigidbody2D>();*/
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.IsGameplay)
        {
            anim.SetBool("isGamePlay", true);
            transform.Translate(forwordSpeed * Time.deltaTime, 0, 0); 
        }

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isGrounded = true;
            anim.SetBool("IsJump", false);

        }
        
    }
    /*private void OnCollisionExit2D(Collision2D collision)
    {

        

    }
    IEnumerator EnemyJump()
    {
        yield return new WaitForSeconds(.2f);
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Enemy.velocity.x, forwordSpeed * 10f));
        anim.SetBool("IsJump", true);

    }
    public void JumpController()
    {
        print("helooo");
        //this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Enemy.velocity.x, forwordSpeed * 30f));
        StartCoroutine(EnemyJump());
        
    }*/

}
