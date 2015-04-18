using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float minX,maxX,minZ,maxZ;
}

public class PlayerController : MonoBehaviour {
	public float speed;
	public float fireRate;
	public Boundary b;
	public GameObject shot;
	public int strength;
	public Transform shotSpawn;
	private float nextFire;
	private float rot;
	AudioSource playMe;
	Rigidbody rb;
	bool rolling;


	void Start(){
		rb = GetComponent<Rigidbody> ();
		playMe = GetComponent<AudioSource> ();
		nextFire = 0.0f;
		rot = 0;
		rolling = false;
		strength = 1;
	}

	void Update(){
		if (!rolling) {
			if ((Input.GetKey ("space") && Time.time > nextFire)) {
				nextFire = Time.time + fireRate;
				switch(strength){
				case 1:
					ShootingPattern1();
					break;
				case 2:
					ShootingPattern2();
					break;
				case 3:
					ShootingPattern3();
					break;
				default:
					ShootingPattern1();
					break;
				}
			} else if (Input.GetKey (KeyCode.B)) {
				rolling = true;
			}		
		}
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxisRaw("Horizontal");
		float moveVertical = Input.GetAxisRaw("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;
		if (rolling) {
			rb.transform.Rotate(Vector3.forward,20);
			if(moveHorizontal!=0){
				rb.velocity *= 1.8f;
			}
			rot += 20;
			if(rot >= 360){
				rot = 0;
				rolling = false;
			}
		}
		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x,b.minX,b.maxX), 
			0.0f, 
			Mathf.Clamp(rb.position.z,b.minZ,b.maxZ));
	}
	
	void ShootingPattern1(){
		Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
		playMe.Play();
	}
	
	void ShootingPattern2(){
		Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
		shotSpawn.transform.Rotate(0,10,0);
		Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
		shotSpawn.transform.Rotate(0,-20,0);
		Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
		shotSpawn.transform.Rotate(0,10,0);
		playMe.Play();
	}
	
	void ShootingPattern3(){
		Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
		shotSpawn.transform.Rotate(0,10,0);
		Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
		shotSpawn.transform.Rotate(0,-20,0);
		Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
		shotSpawn.transform.Rotate(0,15,0);
		Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
		shotSpawn.transform.Rotate(0,-10,0);
		Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
		shotSpawn.transform.Rotate(0,5,0);
		playMe.Play();
	}

	public int GetLevel(){
		return strength;
	}

	public void LevelUp(){
		strength++;
	}
}
