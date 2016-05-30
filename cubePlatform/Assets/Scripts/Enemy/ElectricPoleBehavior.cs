using UnityEngine;
using System.Collections;

public class ElectricPoleBehavior : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		if(col.transform.tag == "Player") {
			col.transform.GetComponent<PlayerMovement>().IsDead(true);
		}
	}
}
