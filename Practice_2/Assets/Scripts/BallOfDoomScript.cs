using UnityEngine;
using System.Collections;

public class BallOfDoomScript : MonoBehaviour {
	public float numRings = 5;
	public int numShots = 36;
	public GameObject shot;
	public float fireRate = 0.5f;
	public float speed = 0.5f;
	
	private bool firing;

	void Start () {
		StartCoroutine (fire ());
	}

	public void FixedUpdate(){
		if (!firing) {
			StartCoroutine (fire ());
		} 

	}

	IEnumerator fire(){
		firing = true;
		float rot = 360/numShots;
		yield return new WaitForSeconds(2);
		for (int x = 0; x < numRings; x++) {
			for (int i = 1; i <= numShots; i++) {
				transform.Rotate(0,rot,0);
				Instantiate(shot,transform.position,transform.rotation);
			}
			transform.Rotate(0,15,0);
			yield return new WaitForSeconds(fireRate);
		}
		firing = false;
	}

}
