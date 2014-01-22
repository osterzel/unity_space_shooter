using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Mover : MonoBehaviour {

	public float speed;
	public int strafe;
	public int tilt;
	public int strafespeed;
	public Boundary boundary;
	private int horizontalmovement;

	void Start() {

		if (strafe == 0) {
			rigidbody.velocity = transform.forward * speed;
		} else {
			Random random = new Random();
			horizontalmovement = Random.Range (strafespeed * -1, strafespeed);
			Debug.Log ("Current Movement: " + horizontalmovement);
		}

	}

	void Update() {

		if (strafe == 1) {

			if ( rigidbody.position.x == boundary.xMin ) {
				horizontalmovement = horizontalmovement * -1;
			}
			if ( rigidbody.position.x == boundary.xMax ) {
				horizontalmovement = horizontalmovement * -1;
			}
			
			Vector3 movement = new Vector3 (horizontalmovement, 0.0f, 1.0f);
			
			rigidbody.velocity = movement * speed;

			//Debug.Log ("Current positions: " + rigidbody.position.x + ":" + boundary.xMin + ":" + boundary.xMax);

			rigidbody.position = new Vector3 
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax),
				0.0f,
				rigidbody.position.z
			);
			
			//rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
		}
		
	}



}
