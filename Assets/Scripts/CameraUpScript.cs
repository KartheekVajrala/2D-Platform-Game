using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpScript : MonoBehaviour {
    public float upvelocity;
    public GameObject plank;
    public float timebetwenspwan;
    private float t = 0f;
    public PlayerController player;
    public GameObject checkpoint;

	void Start () {
        StartCoroutine("plankspawn");
        player = FindObjectOfType<PlayerController>();
	}
	
	void Update () {
        t += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y + upvelocity * Time.deltaTime,transform.position.z);
        upvelocity = Mathf.Lerp(0.3f, 1.8f, t / 75f);
        timebetwenspwan = Mathf.Lerp(6f, 1.7f, t / 75f);
	}

    public IEnumerator plankspawn()
    {
        while ((t / 75f) < 1.1f)
        {
            float randy = Random.Range(transform.position.x - 5.5f, transform.position.x + 5.5f);
            Destroy(Instantiate(plank,new Vector2(randy, transform.position.y + 3f), Quaternion.identity),20f);
            yield return new WaitForSeconds(timebetwenspwan);
        }
        Instantiate(plank, new Vector2(transform.position.x, transform.position.y + 3f), Quaternion.identity);
        Instantiate(checkpoint, new Vector2(transform.position.x, transform.position.y + 4f), Quaternion.identity);
    }
}
