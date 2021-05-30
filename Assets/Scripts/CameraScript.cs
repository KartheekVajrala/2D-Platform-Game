using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public GameObject player;
    public float offset = 8f;
    private Vector3 playerpos;
    public float switchtime;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        playerpos = player.transform.position;
        if(player.transform.localScale.x > 0f)
        {
            playerpos = new Vector3(player.transform.position.x + offset, transform.position.y, transform.position.z);
        }
        else
        {
            playerpos = new Vector3(player.transform.position.x - offset, transform.position.y, transform.position.z);
        }
        transform.position = Vector3.Lerp(transform.position, playerpos, switchtime* Time.deltaTime);
	}
}
