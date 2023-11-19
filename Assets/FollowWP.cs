using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWP = 0;

    public float speed = 10.0f;
    public float rptspeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, waypoints[currentWP].transform.position) < 3)
        {
            currentWP++;
        }
        if(currentWP >= waypoints.Length)
        {
            currentWP = 0;
        }
        //this.transform.LookAt(waypoints[currentWP].transform);
        Quaternion lookatWP = Quaternion.LookRotation(waypoints[currentWP].transform.rotation - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, lookatWP, Time.deltaTime * rptspeed);
        this.transform.Translate(0,0,speed * Time.deltaTime);
    }
}
