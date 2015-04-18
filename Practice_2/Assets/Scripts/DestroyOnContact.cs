using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public GameObject power_up;
	public int val;

	private GameController gc;
	void Start(){
		GameObject gcobj = GameObject.FindWithTag ("GameController");
		if (gcobj != null) {
			gc = gcobj.GetComponent<GameController> ();
		} 
		else {
			Debug.Log ("Cannot find script");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy" || other.tag == "Boundary" || other.tag == "Asteroid" || other.tag == "PowerUp") {
		} 
		else {
			Instantiate (explosion,transform.position,transform.rotation);
			if(other.tag == "Player"){
				Instantiate(playerExplosion,other.transform.position,other.transform.rotation);
				gc.GameOver();
			}

			gc.AddScore(val);
			if(gc.SpawnPowerUp()){
				Instantiate(power_up,transform.position,transform.rotation);
			}
			Destroy (other.gameObject);
			Destroy (gameObject);

		}
	}
}
