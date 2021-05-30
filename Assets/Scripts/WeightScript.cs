using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightScript : MonoBehaviour {

    public int Damage;
    public GameObject explosion;
    public LevelManager gameManager;
    public AudioClip explode;

    // Use this for initialization
    void Start()
    {
        gameManager = FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy") { return; }
        if (explosion)
        {
            GameObject explosionins = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosionins, 2);
            gameManager.playaudio.clip = explode;
            gameManager.playaudio.Play();
        }
        Destroy(gameObject);
    }
}
