using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour {

    public float velocity = 5f;
    public float jumpv = 8f;
    public float pushback = 5f;
    private float move = 0f;
    public Transform groundcheckpoint;
    public float groundcheckradius;
    public LayerMask ground;
    private bool istouchground;
    Rigidbody2D myrigidbody;
    private Animator playeranimation;
    public Vector3 restart;
    private LevelManager gameManager;
    private bool hurt = false;
    public AudioClip jump;
    public AudioClip coinpickup;
    public AudioClip damage;
    private AudioSource playaudio;
    [HideInInspector]public int CPreached = 0;

	void Start () {
        myrigidbody = GetComponent<Rigidbody2D>();
        playeranimation = GetComponent<Animator>();
        restart = transform.position;
        gameManager = FindObjectOfType<LevelManager>();
        playaudio = GetComponent<AudioSource>();
	}
	
	void Update () {
        if (hurt == false) { movement(); }
        else
        {
            if (Mathf.Abs(myrigidbody.velocity.x) < 0.1f) { hurt = false; }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Checkpoint")
        {
            if(collision.GetComponent<checkPoint>().reachcheckpoint == false)
            {
                restart = collision.transform.position;
                playaudio.clip = coinpickup;
                playaudio.Play();
                CPreached++;
                collision.GetComponent<checkPoint>().reachcheckpoint = true;
            }
            if (CPreached >= 2 && gameManager.Score > 0) { gameManager.nextlevel(); }
        }
        if(collision.tag == "FallDetector")
        {
            gameManager.healthControl(-100);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            playaudio.clip = damage;
            playaudio.Play();
            float dir = 1f;
            if(collision.transform.position.x > transform.position.x) { dir = -1f; }
            hurt = true;
            myrigidbody.velocity = new Vector2(dir * pushback, myrigidbody.velocity.y);
            playeranimation.SetTrigger("Damage");
            if (collision.gameObject.GetComponent<EnemyScript>()) {
                gameManager.healthControl(collision.gameObject.GetComponent<EnemyScript>().Damage * -1);
            }
            else { gameManager.healthControl(collision.gameObject.GetComponent<WeightScript>().Damage * -1); }
            
        }
    }
    private void movement()
    {
        istouchground = Physics2D.OverlapCircle(groundcheckpoint.position, groundcheckradius, ground);
        move = Input.GetAxis("Horizontal");
        if (move > 0f)
        {
            myrigidbody.velocity = new Vector2(move * velocity, myrigidbody.velocity.y);
            transform.localScale = new Vector2(6.5f, 6.5f);
        }
        else if (move < 0f)
        {
            myrigidbody.velocity = new Vector2(move * velocity, myrigidbody.velocity.y);
            transform.localScale = new Vector2(-6.5f, 6.5f);
        }
        else
        {
            myrigidbody.velocity = new Vector2(0, myrigidbody.velocity.y);
        }
        if (Input.GetButtonDown("Jump") && istouchground)
        {
            myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, jumpv);
            playaudio.clip = jump;
            playaudio.Play();
        }
        playeranimation.SetFloat("Velocity", Mathf.Abs(myrigidbody.velocity.x));
        playeranimation.SetBool("onground", istouchground);
    }
}
