using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateLimiter : MonoBehaviour {

    [Header("Limit Frame Rate")]
    public bool LimitFrameRate = false;

    [Header("Parameters")]
    public GameObject Bouncy;
    public int NumberOfObjectsToSpawn = 10000;
    public Vector3 MinOffset;
    public Vector3 MaxOffset;
    private List<GameObject> bouncies = new List<GameObject>();


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (LimitFrameRate)
        {
            if (bouncies.Count < NumberOfObjectsToSpawn)
            {
                SpawnObject(NumberOfObjectsToSpawn - bouncies.Count);
            }
            else if (bouncies.Count > NumberOfObjectsToSpawn)
            {
                DespawnObject(bouncies.Count - NumberOfObjectsToSpawn);
            }
        }
    }

    void SpawnObject(int number)
    {
        for (int i = 0; i <number; i++)
        {
            var b = Instantiate(Bouncy,
                transform.position - new Vector3(Random.Range(MinOffset.x, MaxOffset.x), Random.Range(MinOffset.y, MaxOffset.y), Random.Range(MinOffset.z, MaxOffset.z)),
                Quaternion.identity,
                transform);
            bouncies.Add(b);
        }
    }

    void DespawnObject(int number)
    {
        for (int i = 0; i < number; i++)
        {
            var b = bouncies[0];
            bouncies.RemoveAt(0);
            Destroy(b);
        }
    }
}
