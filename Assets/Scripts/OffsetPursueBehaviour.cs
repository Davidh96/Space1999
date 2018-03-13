using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursueBehaviour : SteeringBehaviour {

    public Boid leader;
    Vector3 offset;
    Vector3 worldTarget;

    public override Vector3 Calculate()
    {
        worldTarget = leader.transform.TransformPoint(offset);

        float dist = Vector3.Distance(worldTarget, transform.position);
        float time = dist / boid.maximumSpeed;

        Vector3 targetPos = worldTarget + (time * leader.velocity);

        return boid.ArriveForce(targetPos, 500);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, worldTarget);
    }

    // Use this for initialization
    void Start () {
        offset = transform.position - leader.transform.position;
	}
	
	// Update is called once per frame
	void Update () {


	}
}
