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

    abstract public Vector3 Calculate();
}
