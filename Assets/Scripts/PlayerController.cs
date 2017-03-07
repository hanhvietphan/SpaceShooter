using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MinMax
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {

    public float speed;
    public MinMax minmax;
    public float tilt;
    private Rigidbody rb;

	void Start () {

        rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, minmax.xMin, minmax.xMax), 0.0f, Mathf.Clamp(rb.position.z, minmax.zMin, minmax.zMax));

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}