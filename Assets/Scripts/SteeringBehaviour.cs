using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringBehaviour : MonoBehaviour {

    [HideInInspector]
    public Boid boid;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Awake()
    {
        boid = GetComponent<Boid>();
    }

    //the force will be calculated here
    abstract public Vector3 Calculate();
}
