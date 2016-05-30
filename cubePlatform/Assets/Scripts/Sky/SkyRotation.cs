using UnityEngine;
using System.Collections;

public class SkyRotation : MonoBehaviour {

	void FixedUpdate () {
		GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,2) * Time.deltaTime ;
	}
}
