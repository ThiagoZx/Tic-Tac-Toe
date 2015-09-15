using UnityEngine;
using System.Collections;

public class ChildVerifier : MonoBehaviour {
	public bool hasChild;
	public bool child;
	
	void Update () {
		if (transform.childCount != 0) {
			hasChild = true;
			child = gameObject.GetComponentInChildren<ItemBehaviour>().followMouse;
			//gameObject.tag = "FullSlot";
		} else {
			if(!child)
				hasChild = false;
			//gameObject.tag = "EmptySlot";
		}
	}
}
