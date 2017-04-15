using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleCollision : MonoBehaviour {

    public static BlackHoleCollision Instance { get; set; }

    // Use this for initialization
    void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GravitationalPull.Instance.CollisionCount++;
        GravitationalPull.Instance.CollisionMass += collision.GetComponent<Rigidbody2D>().mass;
        AsteroidManager.Instance.RemoveAndDestroyAndRespawn(collision.gameObject);
    }
}
