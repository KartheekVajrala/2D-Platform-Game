using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    private LevelManager gameManager;
    public int CoinValue;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameManager.scoreCount(CoinValue);
            Destroy(gameObject);
        }
    }
}
