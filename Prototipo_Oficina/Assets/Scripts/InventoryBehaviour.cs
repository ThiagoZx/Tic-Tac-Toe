using UnityEngine;
using System.Collections;

public class InventoryBehaviour : MonoBehaviour {

	private string InventoryStatus;
	private float velocity = 0.05f;
	private float acceleration = 0.01f;
	private bool above = false;
	private bool inBound = false;
	public bool onItem = false;

	void OnMouseEnter(){
		InventoryStatus = "Working";
		velocity = 0.05f;
		acceleration = 0.01f;
		above = true;
		if(GetComponentInChildren<ChildVerifier>().hasChild == true)
			GameObject.FindGameObjectWithTag ("Item").collider2D.enabled = false;

		StartCoroutine (MovementGO ());
	}

	void OnMouseExit(){
		velocity = 0.05f;
		acceleration = 0.01f;
		above = false;

		if (inBound) {
			InventoryStatus = "WaitToWork";
			StartCoroutine (WaitToMove ());
		} else if(!inBound){
			InventoryStatus = "NotWorking";
			StartCoroutine (MovementBACK ());
		}
	}

	IEnumerator MovementGO(){
		if (InventoryStatus == "Working") {
			if (transform.position.y > 4.4f) {
				velocity = velocity + acceleration;
				transform.position = new Vector2 (transform.position.x, transform.position.y - velocity);
			} else {
				transform.position = new Vector2 (transform.position.x, 4.4f);
				inBound = true;
				if(GetComponentInChildren<ChildVerifier>().hasChild == true)
					GameObject.FindGameObjectWithTag ("Item").collider2D.enabled = true;
			}

			if(transform.position.y >= 5.1f && transform.position.y <= 5.2f){
				acceleration = acceleration * -1f;
			}

			yield return new WaitForSeconds (0.023f);

			if (transform.position.y != 4.4f) {
				StartCoroutine (MovementGO ());
			}
		}
	}

	IEnumerator MovementBACK(){
		if (InventoryStatus == "NotWorking") {
			if (transform.position.y < 5.9f) {
				velocity = velocity + acceleration;
				transform.position = new Vector2 (transform.position.x , transform.position.y + velocity);
				inBound = false;
			} else {
				transform.position = new Vector2 (transform.position.x, 5.9f);
			}

			if(transform.position.x >= 5.1f && transform.position.x <= 5.2f){
				acceleration = acceleration * -1f;
			}

			yield return new WaitForSeconds (0.023f);

			if (transform.position.x != 5.9f) {
				StartCoroutine (MovementBACK ());
			}
		}
	}

	IEnumerator WaitToMove(){
		yield return new WaitForSeconds (1f);
		if (above || onItem) {
			InventoryStatus = "Working";
			StartCoroutine (MovementGO ());
		} else {
			InventoryStatus = "NotWorking";
			StartCoroutine (MovementBACK ());
		}
	}
}