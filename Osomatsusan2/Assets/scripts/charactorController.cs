using UnityEngine;
using System.Collections;

public class charactorController : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("left")) {
			transform.Rotate(new Vector3(0f,-1.0f,0f)); 
		}
		if (Input.GetKey ("right")) {
			transform.Rotate(new Vector3(0f,1.0f,0f)); 
		}
		if (Input.GetKeyDown ("up")) {
			animator.SetBool ("walk", true);
		}
		if (Input.GetKeyUp ("up")) {
			animator.SetBool ("walk", false);
		}
	}
}
