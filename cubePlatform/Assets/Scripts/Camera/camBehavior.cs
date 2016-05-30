using UnityEngine;
using System.Collections;

public class camBehavior : MonoBehaviour {
	
	private GameObject goPoint;
	private GameObject goPlayer;
	private Vector3 camToPointDifference;
//	private Vector3 camDirection;
//	private Vector3 camInitPos;
//	private RaycastHit hitPlus;
//	private RaycastHit hitMinus;
//	private LayerMask lMask;

	float defaultSpeed;
	bool isDownable;
	bool isUpable;
//	bool zoomPlus;
//	bool zoomMinus;
	
	public float speed;
	public float camMaxHeight;
	public float camMinHeight;
	
	void Awake () {
		goPoint = GameObject.Find ("camViewPoint");
		defaultSpeed = 15f;
//		speed = defaultSpeed;
	}

	void FixedUpdate () {
		transform.LookAt(goPoint.transform);

//		camToPointDifference = goPoint.transform.position - transform.position;
//		zoomPlus = !Physics.Raycast(transform.position, camToPointDifference, out hitPlus, 15);
//		zoomPlus = !Physics.Raycast(transform.position, camToPointDifference, 15);
//		zoomMinus = Physics.Raycast(transform.position, camToPointDifference, out hitMinus, 25);
//		zoomMinus = Physics.Raycast(transform.position, camToPointDifference, 25);
//		Debug.DrawRay(transform.position ,  camToPointDifference * 30, Color.blue);

//		if (Input.GetKey(KeyCode.AltGr)) {
//			speed = 40f;
//		} else {
//			speed = defaultSpeed;
//		}

		// Cam DOWN
		if (transform.position.y > camMinHeight) {
			if (Input.GetKey("s")) {
				transform.Translate(Vector3.down * Time.deltaTime * speed);
				transform.RotateAround(Vector3.zero, Vector3.down, Time.deltaTime * speed);
			}
		}
		// Cam UP
		if (transform.position.y < camMaxHeight && transform.rotation.x < 0.45) {
			if (Input.GetKey ("w") ) {
				transform.Translate (Vector3.up * Time.deltaTime * speed);
				transform.RotateAround (Vector3.zero, Vector3.up, Time.deltaTime * speed);
			}
		}
		// Cam  ZOOM ++
//		if (Input.GetKey("g") && transform.rotation.x < 0.5 && zoomPlus) {
//			transform.Translate(Vector3.forward * Time.deltaTime * speed);
//		}
		// Cam ZOOM --
//		if (Input.GetKey("j") && transform.rotation.x > 0 && zoomMinus) {
//			transform.Translate(Vector3.back* Time.deltaTime * speed);
//		}
		// Cam LEFT
		if (Input.GetKey("a")) {
			transform.Translate(Vector3.left * Time.deltaTime * speed);
		}
		// Cam Right
		if (Input.GetKey("d")) {
			transform.Translate(Vector3.right * Time.deltaTime *  speed);
		}
	}
}
