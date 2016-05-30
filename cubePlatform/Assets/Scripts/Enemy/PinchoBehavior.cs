using UnityEngine;
using System.Collections;

public class PinchoBehavior : MonoBehaviour {
	public float mroPosition;
	public float mroSpeed;
	public float mroDistance;
	public bool moveUp;
	public float timer;

	Vector3 initialTrans;
	
	private AudioClip blob;
	private AudioSource source;
	bool activateSound;
	
	void Awake() {
		initialTrans = transform.position;
		moveUp = true;
		source = GetComponent<AudioSource>();
		blob = GetComponent<AudioClip>();
		activateSound = true;
	}

	void FixedUpdate () {

		mroPosition = transform.position.y;
		if (moveUp == true) {
			Invoke("MoveUp",timer);
		} else {
			MoveDown ();
		}
	}
	
	void MoveUp(){
		if ((initialTrans.y - mroDistance) < mroPosition && moveUp) {
			transform.Translate (Vector3.down * Time.deltaTime * mroSpeed);
//			transform.GetComponent<Rigidbody>().AddForce(Vector3.down * mroSpeed, ForceMode.Force);
			return;
		}
		if(activateSound) {
			source.Play();
			activateSound = !activateSound;
		}
		moveUp = false;
	}
	
	void MoveDown(){
		if ((initialTrans.y) > mroPosition && !moveUp) {
			transform.Translate (Vector3.up * Time.deltaTime * mroSpeed);
//			transform.GetComponent<Rigidbody>().AddForce(Vector3.up * mroSpeed, ForceMode.Force);
			return;
		}
		if(!activateSound){
			activateSound = true;
		}
		moveUp = true;
	}	
	
	void OnTriggerEnter(Collider col){
		if(col.transform.tag == "Player") {
			col.transform.GetComponent<PlayerMovement>().IsDead(true);
		}
	}
}
