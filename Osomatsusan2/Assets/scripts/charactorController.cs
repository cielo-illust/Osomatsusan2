using UnityEngine;
using System.Collections;

public class charactorController : MonoBehaviour {

	private Vector3 dir;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		dir = transform.position;
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

		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				if (hit.collider.gameObject.tag == "Base") {
					dir = new Vector3 (hit.point.x, hit.point.y, hit.point.z);

					if (Mathf.Abs((transform.position - dir).magnitude) >= 0.1f) {
						animator.SetBool ("walk", true);
						float dx = dir.x - transform.position.x;
						float dz = dir.z - transform.position.z;
						float rad = Mathf.Atan2 (dz, dx);
						float deg = rad * Mathf.Rad2Deg;
						transform.LookAt(new Vector3(dir.x, transform.position.y, dir.z));
					}
				}
			}
		}

		if (Mathf.Abs((transform.position - dir).magnitude) < 0.1f) {
			animator.SetBool ("walk", false);
		}
	}
}
