using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	private float speed;
	
	private Rigidbody rb;
	private int count;
	
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
        speed = 7;
		count = 0;
	}


	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		
		rb.AddForce (movement * speed);
	}
	
	void OnTriggerEnter(Collider other) 
	{

		if (other.gameObject.CompareTag ( "Lava"))
		{
			transform.position = new Vector3(0, 5, 0);
			count = count + 1;
		}

		if (other.gameObject.CompareTag ( "Bounce"))
		{
			rb.AddForce(Vector3.up * 800 );
		}

        if (other.gameObject.CompareTag("Agua"))
        {
            rb.drag = 2;
            Physics.gravity = new Vector3(0, -5, 0);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Agua"))
        {
            rb.drag = 0;
            Physics.gravity = new Vector3(0, -10, 0); 
        }

    }


        Vector3 jump = new Vector3(0.0f,400,0.0f);
	public bool InAir=false;

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Untagged"&&InAir==true){
			InAir = false;
		}
	}
	
	void OnCollisionStay(Collision other){
		if (other.gameObject.tag == "Untagged" && InAir == true) {
			InAir = false;
		}
	}
	
	void OnCollisionExit(Collision other)
	{
		InAir = true;
	}
	void Update () {
		if(Input.GetKeyDown("space")&&InAir==false)
		{
			rb.AddForce(jump);
		}
	}
	
	
}