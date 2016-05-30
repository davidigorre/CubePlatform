using UnityEngine;
using System.Collections;

public class WallBehavior : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {
		if (col.transform.tag == "Player") {
			Destroy(col.gameObject);
		}
	}
}
