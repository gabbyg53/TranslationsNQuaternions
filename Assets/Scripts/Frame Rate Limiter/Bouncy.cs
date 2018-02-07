using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bouncy : MonoBehaviour {

    public float MinForce;
    public float MaxForce;

    Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        //Random.Range(MinForce, MaxForce) * other.contacts[0].normal
        rb.AddExplosionForce(Random.Range(MinForce, MaxForce), 
            other.contacts[0].point, 
            3.0f);
    }
}
