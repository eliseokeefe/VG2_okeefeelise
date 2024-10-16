using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Q4 {
public class Enemy : MonoBehaviour
{
    
    NavMeshAgent navAgent; 
    public Transform target;
    public Transform patrolRoute; 
    int patrolIndex; 
    public Transform priorityTarget; 
    public float chaseDistance; 
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(patrolRoute){
            target = patrolRoute.GetChild(patrolIndex);
            float distance = Vector3.Distance(transform.position, target.position);
            print("Distance: " + distance);
            if(distance <= 1.75f){
                patrolIndex++;
                if(patrolIndex >= patrolRoute.childCount){
                    patrolIndex = 0;
            }
            }
        }
        if(priorityTarget){
            float priorityTargetDistance = Vector3.Distance(transform.position, priorityTarget.position);
            if(priorityTargetDistance <= chaseDistance){
                target = priorityTarget;
                GetComponent<Renderer>().material.color = Color.red;
            } else {
                GetComponent<Renderer>().material.color = Color.white;
                

                }
        }

        if(target){
            navAgent.SetDestination(target.position);
        }

    }
}
}
