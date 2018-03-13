using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {

        //get leader eagle
        target = GameObject.FindGameObjectWithTag("Leader");
		
	}
	
	// Update is called once per frame
	void Update () {
        //look at target eagle
        transform.LookAt(target.transform);
	}
}
