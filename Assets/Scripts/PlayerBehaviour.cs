using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerBehaviour : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	public float tilt;
	public Transform shotspawn;
	public GameObject shot;
	private Vector3 targetPosition;
	public float fireRate;
	public float nextFire;

	void Update() {

		if (Input.GetButton ("Fire1") && Time.time > nextFire) {

			Instantiate (shot, shotspawn.position, shotspawn.rotation);
			nextFire = Time.time + fireRate;
			audio.Play();
		}
	}

	void FixedUpdate() {

		/*if (Application.platform != RuntimePlatform.IPhonePlayer) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

			rigidbody.velocity = movement * speed;

			rigidbody.position = new Vector3 
(
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax),		
			0.0f,
			Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
			);

			rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
		} else {*/
			if (Input.touchCount >= 1) {
				Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
				Plane plane = new Plane(Vector3.up, 0f);
				float enter;
				plane.Raycast(ray, out enter);
				targetPosition = ray.GetPoint(enter);
			}

		targetPosition.x = Mathf.Clamp (targetPosition.x, boundary.xMin, boundary.xMax);
		targetPosition.z = Mathf.Clamp (targetPosition.z, boundary.zMin, boundary.zMax);
		float distance = Vector3.Distance (targetPosition, rigidbody.position);

		rigidbody.position = Vector3.Lerp (rigidbody.position, targetPosition, 0.01f + (distance / 70));


		//}
	}

}
