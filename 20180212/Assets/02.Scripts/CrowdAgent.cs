using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class CrowdAgent : MonoBehaviour {
    public Transform target;
    private NavMeshAgent agent;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(4f, 5f);
        agent.SetDestination(target.position);
	}
}
