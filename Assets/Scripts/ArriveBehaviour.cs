using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveBehaviour : SteeringBehaviour {

    public Vector3 target;
    public float slowingDistance = 500;

    public override Vector3 Calculate()
    {
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
