using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float delay;
    public PlayerController player;
    public int Score;
    public float Health = 100;
    public Text Scoretext;
    public GameObject healthbar;
    public Button restartbutton;
    public Button mainmenubutton;
    public AudioSource playaudio;
    public AudioClip damage;
    public AudioClip levelstart;

    void Start () {
        player = FindObjectOfType<PlayerController>();
        if (Scoretext) { Scoretext.text = "Score : " + Score; }        
        playaudio = GetComponent<AudioSource>();
        if (levelstart){ playaudio.clip = levelstart;playaudio.volume = 0.4f; playaudio.Play(); }
        healthbar.transform.localScale = new Vector3(Health / 100,healthbar.transform.localScale.y,healthbar.transform.localScale.z);
    }
	void Update () {
		if(SceneManager.GetActiveScene().buildIndex == 3 && player.CPreached>0) { gotomenu(); }
	}

    public void scoreCount(int coinval)
    {
        Score += coinval;
        playaudio.clip = player.coinpickup;
        playaudio.Play();
        Scoretext.text = "Score : " + Score;
        if(player.CPreached == 2 && Score > 0) { nextlevel(); }
    }

    public void healthControl(float healthvalue)
    {
        Health += healthvalue;
        if(Health > 100f) { Health = 100f; }
        if(Health <= 0f) {
            Health = 0f;
            player.gameObject.SetActive(false);
            restartbutton.gameObject.SetActive(true);
            mainmenubutton.gameObject.SetActive(true);
        }
        healthbar.transform.localScale = new Vector3(Health / 100, healthbar.transform.localScale.y, healthbar.transform.localScale.z);
    }
    public void restartlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void gotomenu() { SceneManager.LoadScene(0); }

    public void nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
