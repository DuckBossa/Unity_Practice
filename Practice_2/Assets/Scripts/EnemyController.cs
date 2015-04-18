using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public float fireRate = 1f;
	public Transform shotSpawn;
	public GameObject shot;
	public float speed = 3f;
	private GameObject player;
	private Rigidbody rb;
	private float nextFire;
	private GameController gc;
	private AudioSource playMe;
	void Start () {
		nextFire = 2f;
		player = GameObject.FindGameObjectWithTag ("Player");
		gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		rb = GetComponent<Rigidbody> ();
		playMe = GetComponent<AudioSource> ();
	}

	void FixedUpdate () {
		if (!gc.gameOver) {
			Vector3 playerPos = player.transform.position;
			Vector3 enemyPos = transform.position;
			Vector3 dir = (playerPos - enemyPos).normalized;
			rb.velocity = dir * speed;
			if(Time.time > nextFire){
				nextFire = Time.time + fireRate;
				fire();
			}

		}
		else{
			rb.velocity = Vector3.back * speed;
		}
	}


	void fire(){
		Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
		playMe.Play();
	}
}

