using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float speed;
	public float force;
	Rigidbody rb;
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}

	void FixedUpdate(){
		rb.AddForce(0,0,force);
	}

}
