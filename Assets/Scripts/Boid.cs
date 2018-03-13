using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

    public float maximumSpeed = 10;
    public float mass = 1;

    public Vector3 velocity;
    Vector3 force;

    List<SteeringBehaviour> behaviours = new List<SteeringBehaviour>();

    
	// Use this for initialization
	void Start () {
        SteeringBehaviour[] bh = GetComponents<SteeringBehaviour>();
		foreach(SteeringBehaviour sb in bh)
        {
            behaviours.Add(sb);
        }
	}
	
	// Update is called once per frame
	void Update () {

        force = Calculate();

        Vector3 acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, maximumSpeed);

        transform.position += velocity;
		
	}

    Vector3 Calculate()
    {
        force = Vector3.zero;

        foreach(SteeringBehaviour bh in behaviours)
        {
            if (bh.isActiveAndEnabled)
            {
                force += bh.Calculate();
            }
        }

        return force;
    }

    public Vector3 SeekForce(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= maximumSpeed;
        return desired - velocity;
    }

    public Vector3 ArriveForce(Vector3 target,float slowingDistance)
    {
        Vector3 desired = target - transform.position;
        float rampedSpeed = maximumSpeed * (desired.magnitude / slowingDistance);
        rampedSpeed = Mathf.Min(maximumSpeed, rampedSpeed);
        desired.Normalize();
        desired *= rampedSpeed;

        return desired - velocity;
    }
}
