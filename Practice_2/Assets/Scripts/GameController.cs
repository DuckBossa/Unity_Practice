using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public GameObject hazard2;
	public GameObject enemy;
	public GameObject enemy2;
	public GameObject ball_of_doom;
	public float spawnRate;
	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	public int numSpawnHazard;
	public int numSpawnHazard2;
	public int numSpawnEnemy;
	public int numSpawnEnemy2;
	public int maxBOD;
	public int BOD_Z = 22;
	public float BOD_Spawn;
	public Text scoreText;
	public Text restartText;
	public Text gameOverText;
	public bool gameOver;
	private bool restart;
	private int score;
	private int spawnPowerUp;
	private int numBOD;
	private PlayerController player;
	private float nextBOD;
	void Start () {
		numBOD = 0;
		player = GameObject.Find("Player").GetComponent<PlayerController>();
		transform.Rotate(0,180,0);
		restart = gameOver = false;
		score = 0;
		spawnPowerUp = 100;
		restartText.text = "";
		gameOverText.text = "";
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
		nextBOD = BOD_Spawn;
	}

	void Update(){
		if (restart) {
			if(Input.GetKeyDown(KeyCode.R)){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	public void AddScore(int val){
		score += val;
		UpdateScore ();
	}

	public void GameOver(){
		gameOverText.text = "Game Over";
		gameOver = true;

	}

	public bool SpawnPowerUp(){
		if (score < spawnPowerUp) {
			return false;
		} 
		else {
			spawnPowerUp = score + 100;
			return true;
		}
	}

	public int getScore(){
		return score;
	}

	public void PowerUp(int val){
		if (player.GetLevel () >= 3) {
			AddScore (val);
		} 
		else {
			player.LevelUp();
		}
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score.ToString ();
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (spawnWait);
		while (true) {
			for(int i =	 0; i < numSpawnHazard; i++){
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnRate);
			}
			for(int i =	 0; i < numSpawnHazard2; i++){
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard2, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnRate);
			}
			for(int i = 0; i < numSpawnEnemy; i++){
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
				Debug.Log(spawnPosition);
				Instantiate (enemy, spawnPosition, transform.rotation);
				yield return new WaitForSeconds(spawnRate);
			}

			for(int i = 0; i < numSpawnEnemy2; i++){
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
				Debug.Log(spawnPosition);
				Instantiate (enemy2, spawnPosition, transform.rotation);
				yield return new WaitForSeconds(spawnRate);
			}
			
			if(nextBOD < Time.time && maxBOD > numBOD){
				nextBOD += Time.time + BOD_Spawn;

				Vector3 spawnPosition;
				switch (numBOD){
					case 0:
						spawnPosition = new Vector3(0,spawnValues.y,BOD_Z);
						break;
					case 1:
						spawnPosition = new Vector3(spawnValues.x/2,spawnValues.y,BOD_Z - 5);
						break;
					case 2:
						spawnPosition = new Vector3(-spawnValues.x/2,spawnValues.y,BOD_Z - 5);
						break;
					default:
						Debug.Log ("Wrong Calculation for number of BODS");
						spawnPosition = new Vector3(0,spawnValues.y,BOD_Z);
						break;
				}
				Instantiate(ball_of_doom,spawnPosition,Quaternion.identity);
				numBOD++;
				yield return new WaitForSeconds(spawnRate);
			}

			yield return new WaitForSeconds(spawnWait);

			if(gameOver){
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
}
