using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	public float tilt;
	Rigidbody rb;
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.angularVelocity = Random.insideUnitSphere * tilt;
	}
}
