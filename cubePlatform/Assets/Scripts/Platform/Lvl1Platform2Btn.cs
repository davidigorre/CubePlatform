using UnityEngine;
using System.Collections;

public class Lvl1Platform2Btn : MonoBehaviour {

	public GameObject go;
	Vector3 initialTrans;
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
//		if (plt1.transform.position.y == initialTrans.y) {
//			Vector3 tmp = plt1.transform.position;
//			tmp.y = plt1.transform.position.y - 1f;
//			
//			plt1.transform.position = tmp;
//			Invoke ("ReturnPlatformPos", trampaTime);
//		}

		rend = go.GetComponent<Renderer>();

		rend.material.SetColor ("_Color", Color.yellow);
		go.GetComponent<MeshCollider> ().enabled = false;
	}
	
	void ReturnPlatformPos(){
//		if (plt1.transform.position.y != initialTrans.y) {
			go.transform.position = initialTrans;
//		}
	}
}
