using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
    public float leveltime = 60f;
    public Text timer;
	void Start () {
        timer.text = leveltime.ToString("F2");
	}
	
	// Update is called once per frame
	void Update () {
        leveltime -= Time.deltaTime;
        timer.text = leveltime.ToString("F2");
        if (leveltime <= 0f) {
            this.gameObject.GetComponent<LevelManager>().healthControl(-100);
            timer.gameObject.SetActive(false);
        }
        if(this.gameObject.GetComponent<LevelManager>().Health <= 0)
        {
            timer.gameObject.SetActive(false);
        }
    }
}
