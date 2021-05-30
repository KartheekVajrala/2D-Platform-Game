using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    public float move_x = 2f;
    public GameObject sparks;
    private float t = 0f;
    private Vector3 initialpos;
    public GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        initialpos = transform.position;
        StartCoroutine("act");
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.position = Vector3.Lerp(initialpos, new Vector3(initialpos.x + move_x, initialpos.y, initialpos.z), t / 2f);
    }
    private IEnumerator act()
    {
        yield return new WaitForSeconds(2f);
        if (sparks) { Destroy(Instantiate(sparks, transform.position, Quaternion.identity),2f); }
        yield return new WaitForSeconds(2f);
        Destroy(Instantiate(laser, transform.position, transform.rotation),2f);
    }
}
