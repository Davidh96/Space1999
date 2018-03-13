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
        leader.tag = "Leader";

        leader.AddComponent<SeekBehaviour>();
        leader.GetComponent<SeekBehaviour>().target = leader.transform.TransformPoint(0, 0, -1000);
        


        for (int i = 0; i < followers; i++)
        {
            float xGap = gap;

            if (i == 1)
            {
                xGap *= -1;
            }

            //for (int j = 0; j < followers; j++)
            //{
            //    GameObject follower = GameObject.Instantiate(prefab);
            //    offset = leader.transform.position + new Vector3(gap * (j+1), 0, gap * (j+1));
            //    follower.transform.position = offset;
            //    follower.transform.rotation = leader.transform.rotation;
            //}

            for (int j = 0; j < followers; j++)
            {
                GameObject follower = GameObject.Instantiate(prefab);
                offset = new Vector3(xGap * (j + 1), 0, gap * (j + 1));
                follower.transform.position = leader.transform.TransformPoint(offset);
                follower.transform.rotation = leader.transform.rotation;

                follower.AddComponent<OffsetPursueBehaviour>();
                follower.GetComponent<OffsetPursueBehaviour>().leader = leader.GetComponent<Boid>();
            }
        }
    }
}
