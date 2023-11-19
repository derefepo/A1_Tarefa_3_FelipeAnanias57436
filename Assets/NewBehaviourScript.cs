using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Transform goal;
    float speed = 5.0f;
    GameObject[] wps;
    int currentWP1 = 0;
    public float rptspeed = 10.0f;
    public GameObject wpManager;
    public float lookahead = 10.0f;
    GameObject currentNode;
    Graph g;
    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        g = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[0];
        
    }
    public void gotoheli()
    {
        g.Astar(currentNode, wps[0]);
        currentWP1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
