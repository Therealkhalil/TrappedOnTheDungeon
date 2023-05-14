using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // *************************************************************************************** //

    private Animator anim;
    [SerializeField] private Joystick joystick;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true,is_dead = false;


    [SerializeField] private ParticleSystem Dust;
    [SerializeField] private GameObject Death,GameOver,UIingame;
    private SpriteRenderer sr;
    private BoxCollider2D trigger;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Text scoreTxt,finalScoreTxt,highscoreTxt,finalHighscoreTxt;

    public int score = 0;
    private float timer;

    // *************************************************************************************** //

    private void Start()
    {
        highscoreTxt.text = "Highscore: " + PlayerPrefs.GetInt("HighScore",0);
        finalHighscoreTxt.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        trigger = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        timer += Time.deltaTime;

        if(timer>=1 && !is_dead)
        {
            timer = 0;
            score++;
            scoreTxt.text = score.ToString();
        }

        horizontal = joystick.Horizontal;
        Flip();

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highscoreTxt.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0);
            finalHighscoreTxt.text =  PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
    }

    private void FixedUpdate()
    {
        if(horizontal != 0)
        {
        anim.SetBool("is_run", true);
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            if(IsGrounded() == true)
            Dust.Play();
        }
        else
        {
         anim.SetBool("is_run", false);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("DEATH"))
        {
            is_dead = true;
            UIingame.SetActive(false);
            sr.enabled = false;
            trigger.isTrigger = true;
            Death.SetActive(true);
            Destroy(gameObject, 1.4f);
            finalScoreTxt.text = score.ToString();

            if(score > PlayerPrefs.GetInt("HighScore", 0))
            { 
              PlayerPrefs.SetInt("HighScore", score);
            }

            GameOver.SetActive(true); 
        }
    }
}