using UnityEngine;
using System.Collections;

public class EnemyBoltScript : MonoBehaviour {

	public GameObject playerExplosion;
	private GameController gc;
	void Start () {
		GameObject gcobj = GameObject.FindGameObjectWithTag ("GameController");
		if (gcobj != null) {
			gc = gcobj.GetComponent<GameController> ();
		} 
		else {
			Debug.Log("Cannot Find Script");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Instantiate(playerExplosion,other.transform.position,other.transform.rotation);
			gc.GameOver();
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}

}
