using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public GameObject shot;
	public Transform shotspawn;
	public float fireRate;
	public float nextFire;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire) {

				Instantiate (shot, shotspawn.position, shotspawn.rotation);
				//nextFire = Time.time + fireRate;
				audio.Play ();
				nextFire = Time.time + fireRate;
		}
		
	}
}
