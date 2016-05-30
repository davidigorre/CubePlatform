using UnityEngine;
using System.Collections;

public class Lvl1Wall1 : MonoBehaviour {

	Vector3 initialTrans;
	public GameObject go;
	public int trampaTime;
	public bool isDebug;
	private Renderer rend;
	
	void Awake () {
		initialTrans = go.transform.position;
	}

	void Update(){
		if(isDebug) {
			Invoke("MovePlatformPos", 0);
			Invoke("ReturnPlatformPos", trampaTime);
			isDebug = false;
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.transform.tag == "Player") {
			Invoke ("MovePlatformPos", 0);
		}
	}
	
	void MovePlatformPos() {
//		if (go.transform.position.y == initialTrans.y) {
//			Vector3 tmp = go.transform.position;
//			tmp.y = go.transform.position.y - 1f;
//
//			go.transform.position = tmp;
//			Invoke ("ReturnPlatformPos", trampaTime);
//		}
		rend = go.GetComponent<Renderer>();
		rend.material.SetColor ("_Color", Color.yellow);
		go.GetComponent<MeshCollider> ().enabled = false;
	}
	
	void ReturnPlatformPos(){
		go.transform.position = initialTrans;
	}
}
