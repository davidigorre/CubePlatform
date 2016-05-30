using UnityEngine;
using System.Collections;

public class Cinta : MonoBehaviour {

	public  float cintaSpeed;	
	Vector2 offset;

	// Update is called once per frame
	void Update () {
		offset = new Vector2(Time.time * cintaSpeed, 0);
		GetComponent<Renderer>().material.mainTextureOffset = -offset;
	}
}
