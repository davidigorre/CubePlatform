using UnityEngine;
using System.Collections;

public class viewPointBehavior : MonoBehaviour {

	public GameObject player;

	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void FixedUpdate () {
		// Fixes the cam position with player
		if (player != null) {
			Vector3 tmp = transform.position;
			tmp.y = player.transform.position.y - 1;

			transform.position = tmp;
		}else {
			player = GameObject.FindGameObjectWithTag("Player");
		}
	}
}
