using UnityEngine;
using System.Collections;

public class SinMove : MonoBehaviour {


	public float speed = -4f;
	public float domain = 5f;
	public float range = 2f;
	private float s;
	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3 (0, 0, speed);
		SetStart (0.5f);
	}
	

	void FixedUpdate () {
		float vx = Mathf.Sin(s)*range;
		s += Time.deltaTime * domain;
		rb.velocity = new Vector3 (vx, 0, speed);
	}

	void SetStart(float s){
		this.s = s;
	}
}
