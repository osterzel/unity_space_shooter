using UnityEngine;
using System.Collections;

public class Tumbler : MonoBehaviour
{
	public float tumble;
	
	void Start ()
	{
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble; 
	}
}