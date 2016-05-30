using UnityEngine;
using System.Collections;

public class Lvl1PiecesMovement : MonoBehaviour {

	float PieceMoveVelocity = 2.75f;


	void Awake(){
	}

	// Update is called once per frame
	void Update () {
			transform.Translate(Vector3.back * Time.deltaTime * PieceMoveVelocity);
		}
}
