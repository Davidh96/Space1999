using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveBehaviour : SteeringBehaviour {

    public Vector3 target;
    //the distance to begin slowing at
    public float slowingDistance = 500;

    public override Vector3 Calculate()
    {
        //arrive at target, begin slowing at slowingDistance
        return boid.ArriveForce(target, slowingDistance);
    }

    // Use this for initialization
    void Start () {
		
	}
	

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, target);
    }
}
