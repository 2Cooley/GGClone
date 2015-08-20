using UnityEngine;
using System.Collections;

public class ApplyPhysics : MonoBehaviour {

    public Vector3 Velocity;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = Velocity;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
