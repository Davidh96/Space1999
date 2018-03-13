using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {

        target = GameObject.FindGameObjectWithTag("Leader");
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target.transform);
	}
}
