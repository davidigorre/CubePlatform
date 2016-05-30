using UnityEngine;
using System.Collections;

public class SkyCollider : MonoBehaviour {

	void OnTriggerExit(Collider col){
		if(col.transform.tag == "Player") {
			col.transform.GetComponent<PlayerMovement>().IsDead(false);
		}
	}
}
