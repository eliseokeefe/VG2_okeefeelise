using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

namespace RTS {
public class RTSCharacterController : MonoBehaviour
{
    Animator animator; 
    NavMeshAgent navAgent;

    public GameObject selectionIndicator; 
    public GameObject attackTarget; 
    public GameObject projectilePrefab; 

    public float attackDistance; 
    public float attackDelay; 

    float _timeSinceLastAttack;

    public void Select(){
        selectionIndicator.SetActive(true);
    }

    public void Deselect(){
        selectionIndicator.SetActive(false);
    }

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
        _timeSinceLastAttack += Time.deltaTime;
        if(attackTarget){
            SetDestination(attackTarget.transform.position);
            if(Vector3.Distance(attackTarget.transform.position, transform.position) <= attackDistance){
                if(_timeSinceLastAttack >= attackDelay){
                    _timeSinceLastAttack = 0; 
                    Vector3 projectileOrigin = transform.position + new Vector3(0, 2f, 0); 
                    Vector3 directiontoTarget = (attackTarget.transform.position - projectileOrigin).normalized; 
                    GameObject projectile = Instantiate( 
                        projectilePrefab, 
                        projectileOrigin, 
                        Quaternion.LookRotation(directiontoTarget)
                    ); 

                    projectile.transform.localScale = Vector3.one * 10f; 
                    projectile.GetComponent<Rigidbody>().AddForce(directiontoTarget * 50f, ForceMode.Impulse);
                    Destroy(projectile, 10f);
                }
            }
    }
    }

   public void SetDestination(Vector3 targetPosition)
    {
        navAgent.destination = targetPosition;
    }
 public void SetTarget(GameObject target){
        attackTarget = target; 
    }
   

}
}
