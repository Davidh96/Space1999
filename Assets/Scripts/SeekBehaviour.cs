using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBehaviour : SteeringBehaviour {

    public Vector3 target;

    public override Vector3 Calculate()
    {
        return boid.SeekForce(target);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, target);
    }
}
