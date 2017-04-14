using UnityEngine;

public class Rotate : MonoBehaviour {

    public float RotateSpeed = 50f;
    public bool RandomRotation = false;
    public float MaxRandomRotationSpeed = 150f;
    public float MinRandomRotationSpeed = 30f;

    private float speed;

    private void Start()
    {
        if (!RandomRotation)
            speed = RotateSpeed;
        else
        {
            speed = Random.Range(MinRandomRotationSpeed, MaxRandomRotationSpeed);
            var isNeg = Random.Range(0, 2) == 1;
            speed *= isNeg ? 1f : -1f;            
        }
    }    

	void Update () {
        this.transform.Rotate(0, 0, -Time.deltaTime * speed);
	}
}
