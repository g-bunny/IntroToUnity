using UnityEngine;
using System.Collections;

public class npcMovement : MonoBehaviour
{
	public float speed;

	void Start ()
	{
		//setting a constant state for each npc, moving left
		speed = Random.Range (1, 4);	
		GetComponent<Rigidbody2D> ().velocity = Vector2.left * speed;
	}
}
