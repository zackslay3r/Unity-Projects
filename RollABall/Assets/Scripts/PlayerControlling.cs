using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlling : MonoBehaviour {
	// this is the speed value. since it is public, we can change it in the scene editor.
	public float speed;
	public Text countText;
	public Text winText;
	private Rigidbody rb;
	private int count;

	void Start()
	{
		// at the start of the game, we would like to store the rigidbody component for the player object.
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate ()
	{
		// this will get the movement out player along the two axis.
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		// horizional is for x, y is 0 cause we dont want our player moving up and z for side to side.
		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Pick Up"))
			{
				other.gameObject.SetActive(false);
				count++;
			SetCountText ();
			}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 13) 
		{
			winText.text = "You Win!";
		}
	}
}
