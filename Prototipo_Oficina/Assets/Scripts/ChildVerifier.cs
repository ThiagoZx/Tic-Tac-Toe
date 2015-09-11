using UnityEngine;
using System.Collections;

public class ChildVerifier : MonoBehaviour {
	public bool hasChild;
	
	void Update () {
		if (transform.childCount != 0) {
			hasChild = true;
		} else {
			hasChild = false;
		}
	}
}
