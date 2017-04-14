using UnityEngine;

public class BackgroundPan : MonoBehaviour {

    public Transform PlayerTransform;
    public float PanSpeed = .7f;
	// Use this for initialization
	void Start () {
        if (PlayerTransform == null)
            Debug.LogError("Need to set player transform on background pan script.");
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector2(PlayerTransform.position.x * PanSpeed, PlayerTransform.position.y * PanSpeed);
	}
}
