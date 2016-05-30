using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public GameObject Player;
	public GameObject goExitButton;
	public GameObject goControls;
	float maxGradesY = 90f;
	float minGradesY = 1f;
	float gradesY;
	float rotateSpeed = 80f;
	bool rotate = false;
	/*

	*/
	Quaternion normalRotation;
	Quaternion changeRotation;
	
	// Use this for initialization
	void Awake () {
		normalRotation = Player.transform.rotation;
		changeRotation = new Quaternion (0f, normalRotation.y + 30f , 0f, 0f);
	}

	void FixedUpdate() {
		gradesY = goControls.transform.rotation.eulerAngles.y;
		if (!rotate && (gradesY < maxGradesY)){
			goControls.transform.Rotate(0f, 1f, 0f);

		}

		if (rotate && (gradesY > minGradesY)){
			goControls.transform.Rotate(0f, -1f, 0f);
		}

	}

	public void Play(){
		Application.LoadLevel("Level_1");
	}
	
	public void Exit(){
		Application.Quit();
	}
	
	public void ControlsButton(){
		rotate= true;
	}
	
	public void BackButton(){
		rotate = false;
	}

	public void ExitbuttonEnter(){
		goExitButton.GetComponent<Animator> ().SetBool ("ExitButton", true);
	}

	public void ExitbuttonExit(){
		goExitButton.GetComponent<Animator> ().SetBool ("ExitButton", false);
	}

	public void OtherbuttonEnter(){
		Player.transform.rotation = changeRotation;
	}

	public void OtherbuttonExit(){
		Player.transform.rotation = normalRotation;
	}
}
