using UnityEngine;

public class Movement : MonoBehaviour {

    public float Speed = .5f;

    Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {

        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        rb.AddForce(new Vector2(inputH * Speed, inputV * Speed));
	}
}
