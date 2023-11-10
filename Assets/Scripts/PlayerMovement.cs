using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    public GameObject Character;
    private Rigidbody2D Player;
    private Animator anim;
    public float speed=10f;
    public bool isGrounded;
    float HorizontalInput;
    public float forwordSpeed;
    private Vector2 direction;
    public bool DoubleJump;
    public int KeyPressCount=0;
    public GameObject deathEffect_1;
    //public GameObject deathEffect_2;
    public bool PinkWater=false;
    public Image slider;
    public float waitTime = .5f;
    public bool gotHitByPosionBubble;
    public bool isPlayerDead;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        Player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void start()
    {
        if(GameManager.Instance.IsGameplay)
        {
            /*anim.SetBool("isGamePlay", true);*/
        }
        Application.targetFrameRate = 60;
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.IsGameplay)
        {
            anim.SetBool("isGamePlay", true);
            transform.Translate(forwordSpeed * Time.deltaTime, 0, 0);
        }
        if (transform.position.y <= -0.82f)
        {

            isGrounded = true;
            anim.SetBool("IsJump", false);
            anim.SetBool("isDoubleJump", false);
        }
        else
        {
            isGrounded = false;
            anim.SetBool("IsJump", true);
        }
        
        if(gotHitByPosionBubble)
        {
            slider.fillAmount -= 1.0f / waitTime * Time.deltaTime;
        }
        
    }
    private void Update()
    {
        if (GameManager.Instance.IsGameplay)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jump();
            }
        }
    }
    private void jump()
    {
        if (isGrounded)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Player.velocity.x, speed * 50f));
            DoubleJump = true;
        }
        else if (DoubleJump && !isGrounded)
        {
            print("Double Jump");
            DoubleJump = false;
            anim.SetBool("isDoubleJump", true);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Player.velocity.x, speed * 50f));
            //enemyController.Instance.JumpController();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.IsGameplay = false;
            GameManager.Instance.GameOver();
            GameManager.Instance.HealthBarColor();
            SoundManager.PlaySfx(SoundManager.Instance.soundGameover);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.IsGameplay = false;
            GameManager.Instance.GameOver();
            SoundManager.PlaySfx(SoundManager.Instance.soundGameover);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("PoisonBubble"))
        {
            //GameManager.Instance.IsGameplay = false;
            deathEffect_1.SetActive(true);
            //deathEffect_2.SetActive(true);
            Destroy(collision.gameObject);
            gotHitByPosionBubble = true;
            StartCoroutine(PoisonDeath());
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //PinkWater = false;
       // isGrounded = false;
        /*if(Player.transform.position.y == -1.92)
        {
           // anim.SetBool("IsJump", false);
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Crate"))
        {
            ScoreManager.Instance.setCrates();
            SoundManager.PlaySfx(SoundManager.Instance.CoinPickUp);
            Destroy(collision.gameObject);
            
        }
        if (collision.gameObject.CompareTag("PinkWater"))
        {
            PinkWater = true;
        }
    }
    IEnumerator PoisonDeath()
    {
        yield return new WaitForSeconds(10f);
        GameManager.Instance.IsGameplay = false;
        SoundManager.PlaySfx(SoundManager.Instance.soundGameover);
        GameManager.Instance.GameOver();
        //deathEffect_2.SetActive(true);
        GameManager.Instance.HealthBar.GetComponent<Image>().color = new Color(0, 0, 0, 25);
        Destroy(gameObject);
    }
    
}
