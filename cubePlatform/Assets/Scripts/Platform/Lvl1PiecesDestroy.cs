using UnityEngine;
using System.Collections;

public class Lvl1PiecesDestroy : MonoBehaviour {

	public GameObject[] pieces;
	public GameObject Exp;
	private AudioSource source;
	private AudioSource pieceSource;
	float expDestroyTime = 0.5f;

	void Awake(){
		Invoke ("InstantiatePiece", 1f );
		source = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider col){
		Destroy (col.gameObject);
		source.Play();
		GameObject explosion = Instantiate (Exp);
		Destroy (explosion, expDestroyTime);
	}

	void InstantiatePiece(){
		int num = Random.Range(0,6);
		GameObject piece = Instantiate (pieces [num]);
		pieceSource = piece.GetComponent<AudioSource>();
		pieceSource.Play();

		Invoke ("InstantiatePiece", Random.Range(1f, 2f));
	}

}
