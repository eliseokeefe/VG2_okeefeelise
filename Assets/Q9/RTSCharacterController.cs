using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

namespace RTS {
public class RTSCharacterController : MonoBehaviour
{
    Animator animator; 
    NavMeshAgent navAgent;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("velocity", navAgent.velocity.magnitude);
    }

    public void SetDestination(Vector3 targetPosition)
    {
        navAgent.destination = targetPosition;
}
}
}
