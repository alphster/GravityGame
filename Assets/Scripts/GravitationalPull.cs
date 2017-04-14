using UnityEngine;

public class GravitationalPull : MonoBehaviour {

    public float Radius = 5f;
    public float GravStrength = 5f;

    private float gravStrengthLerpMin, gravStrengthLerpMax;

	void Start () {
        gravStrengthLerpMax = GravStrength;
        gravStrengthLerpMin = GravStrength * .1f;
	}
		
	void FixedUpdate () {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(this.transform.position, Radius);
        //Debug.Log("GravPulling " + hitColliders.Length + " objects");

        foreach (var hc in hitColliders)
        {
            var hcrb = hc.GetComponent<Rigidbody2D>();

            var distance = Vector2.Distance(this.transform.position, hc.transform.position);

            var pullDirection = this.transform.position - hc.transform.position;
            pullDirection.Normalize();

            var strengthEase = Mathf.Lerp(gravStrengthLerpMin, gravStrengthLerpMax, 1 - (Radius / distance));

            hcrb.AddForce(pullDirection * strengthEase);
        }
	}
}
