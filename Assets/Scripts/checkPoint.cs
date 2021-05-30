using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour {

    public Sprite redflag;
    public Sprite greenflag;
    private SpriteRenderer flagsprite;
    public bool reachcheckpoint = false;

	// Use this for initialization
	void Start () {
        flagsprite = GetComponent<SpriteRenderer>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            flagsprite.sprite = greenflag;
        }
    }
}
