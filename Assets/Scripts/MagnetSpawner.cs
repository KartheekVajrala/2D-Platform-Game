using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetSpawner : MonoBehaviour
{
    public GameObject magnet;
    public GameObject Coins;
    public float nextspwanwait;
    public float minwait;
    public float maxwait;
    public float startwait;
    public float yrange;
    public bool stop;
    private float t = 0f;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("magnetspawn");
    }

    // Update is called once per frame
    void Update()
    {
        nextspwanwait = Random.Range(minwait, maxwait);
    }

    public IEnumerator magnetspawn()
    {
        StartCoroutine("speedchanger");
        yield return new WaitForSeconds(startwait);
        while (!stop)
        {
            float rany = Random.Range(transform.position.y - yrange, transform.position.y + yrange);
            Vector3 spwanpos = new Vector3(transform.position.x,rany, transform.position.z);
            Vector3 spwanpos1 = new Vector3(transform.position.x + Random.Range(2f,12f), rany, transform.position.z);
            Destroy(Instantiate(magnet, spwanpos,Quaternion.Euler(0,0,90)),7f);
            Destroy(Instantiate(Coins, spwanpos1, Quaternion.identity), 4f);
            yield return new WaitForSeconds(nextspwanwait);
        }
    }
    private IEnumerator speedchanger()
    {
        while (t < 0.9f)
        {
            t += (Time.deltaTime / 60f);
            maxwait = Mathf.Lerp(5f, 3f, t);
            yield return null;
        }
    }
}
