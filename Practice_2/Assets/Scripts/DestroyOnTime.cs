using UnityEngine;
using System.Collections;

public class DestroyOnTime : MonoBehaviour {
	public float lifeTime;
	void Start () {
		Destroy (gameObject,lifeTime);
	}
}
