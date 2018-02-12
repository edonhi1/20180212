using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityFlock : MonoBehaviour {
    public float minSpeed = 20f;
    public float turnSpedd = 20f;
    public float randomFreq = 20f;
    public float randomForce = 20f;

    public float toOriginForce = 50f;
    public float toOriginRange = 100f;

    public float gravity = 2f;
    public float avoidanceRadius = 50f;
    public float avoidanceForce = 20f;

    public float followVelocity = 4f;
    public float followRadius = 40f;

    private Transform origin;
    private Vector3 velocity;
    private Vector3 normalizedVelocity;
    private Vector3 randomPush;
    private Vector3 originPush;
    private Transform[] objects;
    private UnityFlock[] otherFlocks;
    private Transform transformComponent;

	void Start () {
        randomFreq = 1f / randomFreq;
        origin = transform.parent;
        transformComponent = transform;
        Component[] tempFlocks = null;
        if (transform.parent)
        {
            tempFlocks = transform.parent.GetComponentsInChildren<UnityFlock>();
        }
        objects = new Transform[tempFlocks.Length];
        otherFlocks = new UnityFlock[tempFlocks.Length];
        for (int i = 0; i < tempFlocks.Length; i++)
        {
            objects[i] = tempFlocks[i].transform;
            otherFlocks[i] = (UnityFlock)tempFlocks[i];
        }
        transform.parent = null;
        StartCoroutine(UpdateRandom());
	}

    IEnumerator UpdateRandom()
    {
        while (true)
        {
            randomPush = Random.insideUnitSphere * randomForce;
            yield return new WaitForSeconds(randomFreq + Random.Range(-randomFreq / 2f, randomFreq / 2f));
        }
    }
	
	void Update () {
		
	}
}
