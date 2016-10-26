using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 2;
	public float jumpForce = 400;
	public AudioSource audio;
	private float point = 0;
	private float scaleX;
	private float scaleY;

	public Text scoreText;

	void Start ()
	{
		GetComponent<Rigidbody2D> ().velocity = Vector2.right * speed;
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpForce);
			if (GetComponent<Rigidbody2D> ().velocity.x <= 0) {
				GetComponent<Rigidbody2D> ().velocity = Vector2.right * speed;
			}
		}
		scaleX = 0.25f + point * 0.1f;
		scaleY = 0.25f + point * 0.1f;
		this.transform.localScale = new Vector3 (scaleX, scaleY, 0);
		setScoreText ();
	}

	//for collision with any objects...
	void OnCollisionEnter2D (Collision2D coll)
	{
		//for collision with ground object
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Death")) {
			SceneManager.LoadScene ("FightingTheMachine");
			//for collision with collectibles
		} else if (coll.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			Destroy (coll.gameObject);
			audio.Play ();
			//scale multiplier, each time an object is "eaten", the multiiplier grows by 1
			point += 1.0f;
			//scale grows bigger
			scaleX = scaleX * point;
			scaleY = scaleY * point;

			//for collision with final gameover object
		} else if (coll.gameObject.layer == LayerMask.NameToLayer ("GameOver")) {
			Destroy (this.gameObject);
		}

	}

	void setScoreText ()
	{
		//setting the value of the text to be printed
		scoreText.text = "Score: " + point.ToString ();
	}
}