using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		Application.LoadLevel("Menu");
	}
}
