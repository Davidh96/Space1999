using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour {

    public float gap = 20;
    public float followers = 2;
    public GameObject prefab;

    private Vector3 offset;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Awake()
    {
        GameObject leader = GameObject.Instantiate(prefab);
        leader.transform.position = transform.position;
        leader.transform.rotation = transform.rotation;
        //set tag of leader to leader
        leader.tag = "Leader";

        //add seek behaviour to leader
        leader.AddComponent<SeekBehaviour>();
        //seek target 1000 units ahead
        leader.GetComponent<SeekBehaviour>().target = leader.transform.TransformPoint(0, 0, 1000);


        //for each row of followers
        for (int i = 0; i < followers; i++)
        {
            float xGap = gap;

            //if on the other side of leader
            if (i == 1)
            {
                xGap *= -1;
            }

            //for each follower on one side
            for (int j = 0; j < followers; j++)
            {
                GameObject follower = GameObject.Instantiate(prefab);
                offset = new Vector3(xGap * (j + 1), 0, gap * (j + 1));
                //place the position behind the leader
                follower.transform.position = leader.transform.TransformPoint(-offset);
                follower.transform.rotation = leader.transform.rotation;

                //add offset pursue steering behaviour
                follower.AddComponent<OffsetPursueBehaviour>();
                //set leader as the leader to offset
                follower.GetComponent<OffsetPursueBehaviour>().leader = leader.GetComponent<Boid>();
            }
        }
    }
}
