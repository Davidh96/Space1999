using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursueBehaviour : SteeringBehaviour {

    public Boid leader;
    Vector3 offset;
    Vector3 worldTarget;

    public override Vector3 Calculate()
    {
        //the target location for the eagle
        worldTarget = leader.transform.TransformPoint(offset);

        //get the distance to target
        float dist = Vector3.Distance(worldTarget, transform.position);
        //t = d/s
        float time = dist / boid.maximumSpeed;

        //calculate target pos
        Vector3 targetPos = worldTarget + (time * leader.velocity);

        return boid.ArriveForce(targetPos, 500);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, worldTarget);
    }

    // Use this for initialization
    void Start () {
        //get the offset location from the leader
        offset = transform.position - leader.transform.position;
        //set orientation of object
        offset = Quaternion.Inverse(leader.transform.rotation) * offset;
	}
	
	// Update is called once per frame
	void Update () {


	}
}
