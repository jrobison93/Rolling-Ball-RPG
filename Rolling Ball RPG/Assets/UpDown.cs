using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpDown : MonoBehaviour {

	public bool Done;
	private float placex, placey, placez;
	public float changex, changey, changez;

	void Start()
	{
		Done = true;
		placex = transform.position.x;
		placey = transform.position.y;
		placez = transform.position.z;
	}

	void OnTriggerEnter(Collider other)
	{
		Done = false;
	}

	void OnCollisionStay()
	{
		Done = false;
		Vector3 up = new Vector3 (placex+changex, placey+changey, placez+changez);
		transform.position = Vector3.Slerp (transform.position, up, Time.deltaTime);
	}

	void OnTriggerExit()
	{
		StartCoroutine (waiting ());
	}

	void OnCollisionExit()
	{
		StartCoroutine (waiting ());
	}


	void Update () 
	{		
		if (Done) 
		{
			Vector3 down = new Vector3 (placex, placey, placez);
			transform.position = Vector3.Slerp (transform.position, down, Time.deltaTime);
		}
	}

	IEnumerator waiting()
	{
		yield return new WaitForSeconds(0.5f);
		Done = true;
	}
}