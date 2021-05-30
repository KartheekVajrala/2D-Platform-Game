using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWeights : MonoBehaviour {

    public GameObject[] enemies;
    public float nextspwanwait;
    public float minwait;
    public float maxwait;
    public float startwait;
    public float xrange;
    public bool stop;
    private float t = 0f;
	// Use this for initialization
	void Start () {
        StartCoroutine("enemyspawn");
	}
	
	// Update is called once per frame
	void Update () {
        nextspwanwait = Random.Range(minwait, maxwait);
	}

    public IEnumerator enemyspawn()
    {
        StartCoroutine("speedchanger");
        yield return new WaitForSeconds(startwait);
        while (!stop)
        {
            int randomenemy = Random.Range(0, enemies.Length);
            Vector3 spwanpos = new Vector3(Random.Range(transform.position.x - xrange, transform.position.x + xrange), transform.position.y,transform.position.z);
            Instantiate(enemies[randomenemy], spwanpos, Quaternion.identity).GetComponent<WeightScript>().Damage = 50;
            yield return new WaitForSeconds(nextspwanwait);
        }
    }
    public IEnumerator speedchanger()
    {
        while (t < 0.9f)
        {
            t += (Time.deltaTime / 60f);
            maxwait = Mathf.Lerp(2f, 1f, t);
            yield return null;
        }
    }
}
