using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    public GameObject[] waypoints2;
    int currentWP1 = 0;

    public float speed = 10.0f;
    public float rptspeed = 10.0f;
    GameObject tracker;
    public float lookahead = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        tracker = gameObject.CreatePrimitive(PrimitiveType.Cylinder);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.transform.position = this.transform.position;
        tracker.transform.rotation = this.transform.rotation;
    }
    void ProgressTracker()
    {
        if (Vector3.Distance(tracker.transform.position, waypoints2[currentWP1].transform.position) < 3)
        {
            currentWP1++;
        }
        if (currentWP1 >= waypoints.Length)
        {
            currentWP1 = 0;
        }
        tracker.transform.LookAt(waypoints[currentWP].transform);
        tracker.transform.Translate(0, 0, (speed +2 ) * Time.deltaTime);

    }

    // Update is called once per frame
    void Update()
    {
        ProgressTracker();
            //this.transform.LookAt(waypoints[currentWP].transform);
            Quaternion lookatWP = Quaternion.LookRotation(waypoints2[currentWP1].transform.rotation - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, lookatWP, Time.deltaTime * rptspeed);
        this.transform.Translate(0,0,speed * Time.deltaTime);
    }
}
