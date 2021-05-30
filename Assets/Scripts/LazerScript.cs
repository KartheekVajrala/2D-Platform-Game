using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour
{
    public LineRenderer myline;
    public Transform lazerpoint;
    public float distanceoflazer = 100f;
    public LevelManager gamemanager;
    private float t;
    void Start()
    {
        gamemanager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        shootlazer();
        t += Time.deltaTime;
    }
    void shootlazer()
    {
        if(Physics2D.Raycast(transform.position, -transform.up))
        {
            RaycastHit2D hitpt = Physics2D.Raycast(transform.position, -transform.up);
            if(hitpt.collider.tag == "Player") { gamemanager.healthControl(-30*Time.deltaTime); }
            Drawline(lazerpoint.position, hitpt.point);
        }
        else
        {
            Drawline(lazerpoint.position, lazerpoint.position - transform.up * distanceoflazer);
        }
    }
    void Drawline(Vector3 pos1,Vector3 pos2)
    {
        myline.SetPosition(0, pos1);
        myline.SetPosition(1, pos2);
    }
}
