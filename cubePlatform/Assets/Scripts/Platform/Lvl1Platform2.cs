using UnityEngine;
using System.Collections;

public class Lvl1Platform2 : MonoBehaviour {

	Vector3 initialTrans;
	float platformPosition;
	bool moveRight;

	public float platformSpeed;
	public float platformDistance;

	// Use this for initialization
	void Awake () {
		initialTrans = transform.position;
		moveRight = true;
	}
	
	void FixedUpdate () {
		platformPosition = transform.position.z;
		if (moveRight == true) {
			MoveRight ();
		} else {
			MoveLeft ();
		}
	}

	void MoveRight(){
		//if ( (initialTrans.z - platformDistance) < platformPosition) {
		if ( (initialTrans.z) < platformPosition) {
			transform.Translate (Vector3.back * Time.deltaTime * platformSpeed);
			return;
		}

		moveRight = false;
	}
	
	void MoveLeft(){
		if ( (initialTrans.z + platformDistance) > platformPosition) {
			transform.Translate (Vector3.forward * Time.deltaTime * platformSpeed);
			return;
		}

		moveRight = true;
	}
}
