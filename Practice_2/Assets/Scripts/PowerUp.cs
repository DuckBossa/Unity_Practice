using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
	public GameObject player;
	public int points = 30;
	public int speed = 5;
	GameController gc;
	Rigidbody rb;

	void Start () {
		gc = GameObject.Find ("Game Controller").GetComponent<GameController> ();
		if (gc == null) {
			Debug.Log ("Script cannot be found");
		}
		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3 (0, 0, speed);
	}

	void OnTriggerEnter(Collider other){
		if (!gc.gameOver) {
			if (other.tag == "Player") {
				gc.PowerUp(points);
				Destroy (gameObject);
			}		
		} 
		else {
			Destroy(gameObject,3f);
		}

	}
}
