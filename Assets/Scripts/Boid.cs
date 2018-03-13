using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

    public float maximumSpeed = 10;
    public float mass = 1;

    public Vector3 velocity;
    Vector3 force;

    //stores all ttached steering behaviours
    List<SteeringBehaviour> behaviours = new List<SteeringBehaviour>();

    
	// Use this for initialization
	void Start () {
        //get the steering behaviours attached to this game object
        SteeringBehaviour[] bh = GetComponents<SteeringBehaviour>();
		foreach(SteeringBehaviour sb in bh)
        {
            behaviours.Add(sb);
        }
	}
	
	// Update is called once per frame
	void Update () {

        force = Calculate();

        //calculate the velocity
        //a = f/m
        Vector3 acceleration = force / mass;
        //v = a*t
        velocity += acceleration * Time.deltaTime;

        //stop object from going too fast
        velocity = Vector3.ClampMagnitude(velocity, maximumSpeed);

        //add velocity to object
        transform.position += velocity;
		
	}

    Vector3 Calculate()
    {
        force = Vector3.zero;

        //calculate force for each steering behaviour
        foreach(SteeringBehaviour bh in behaviours)
        {
            if (bh.isActiveAndEnabled)
            {
                force += bh.Calculate();
            }
        }

        return force;
    }

    //seek target vector
    public Vector3 SeekForce(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= maximumSpeed;
        return desired - velocity;
    }

    //arrive at target vector
    public Vector3 ArriveForce(Vector3 target,float slowingDistance)
    {
        Vector3 desired = target - transform.position;
        //get ramped speed
        float rampedSpeed = maximumSpeed * (desired.magnitude / slowingDistance);
        //prevent object from going too fast
        rampedSpeed = Mathf.Min(maximumSpeed, rampedSpeed);
        desired.Normalize();
        desired *= rampedSpeed;

        return desired - velocity;
    }
}
