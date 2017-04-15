using UnityEngine;

public class Movement : MonoBehaviour {

    public float Speed = .02f;

    Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Move object across XY plane
            //transform.Translate(-touchDeltaPosition.x * Speed, -touchDeltaPosition.y * Speed, 0);
            rb.AddForce(new Vector2(-touchDeltaPosition.x * Speed, -touchDeltaPosition.y * Speed));
        }

        /*
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        rb.AddForce(new Vector2(inputH * Speed, inputV * Speed));
        */
    }
}
