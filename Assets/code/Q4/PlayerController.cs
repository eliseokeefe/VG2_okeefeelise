using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 


namespace Q4 {
public class PlayerController : MonoBehaviour {
    public static PlayerController instance; 
    public Transform povOrigin; 
    public Transform projectileOrigin; 
    public GameObject projectilePrefab; 
    public float attackRange; 
    public List<int> keyIdsObtained; 
    void Awake()
    {
        instance = this; 
        keyIdsObtained = new List<int>();
    }
    // Update is called once per frame

    /*
    void Update()
    {
        Keyboard keyboardInput = Keyboard.current; 
        Mouse mouseInput = Mouse.current;
        if(keyboardInput != null && mouseInput != null) {
            if(keyboardInput.eKey.wasPressedThisFrame){
                Vector2 mousePosition = mouseInput.position.ReadValue();
                Ray ray = Camera.main.ScreenPointToRay(mousePosition);
                RaycastHit hit; 
                if(Physics.Raycast(ray, out hit, 2f)){
                   DoorCode targetDoor = hit.transform.GetComponent<DoorCode>(); 
                   if(targetDoor){
                          targetDoor.Interact();
                   }
                   InteractButton targetButton = hit.transform.GetComponent<InteractButton>();
                     if(targetButton != null)
            {
                targetButton.Interact();
            }

        }
    }
    if(mouseInput.leftButton.wasPressedThisFrame){
        PrimaryAttack();
}
if(mouseInput.rightButton.wasPressedThisFrame){
    SecondaryAttack();
}
}
}
*/ 

void OnInteract(){
    RaycastHit hit; 
   if(Physics.Raycast(povOrigin.position, povOrigin.forward, out hit, 2f)){
        DoorCode targetDoor = hit.transform.GetComponent<DoorCode>(); 
        if(targetDoor){
            targetDoor.Interact();
        }
        InteractButton targetButton = hit.transform.GetComponent<InteractButton>();
        if(targetButton != null)
        {
            targetButton.Interact();
        }
   }
   
       
    
}
void OnPrimaryAttack(){
    RaycastHit hit; 
    bool hitSomething = Physics.Raycast(povOrigin.position, povOrigin.forward, out hit, attackRange);
    if(hitSomething){
        Rigidbody targetRigidbody = hit.transform.GetComponent<Rigidbody>();
        if(targetRigidbody){
            targetRigidbody.AddForce(povOrigin.forward * 100f, ForceMode.Impulse);
        }
    }
}

void OnSecondaryAttack(){
    GameObject projectile = Instantiate(projectilePrefab, projectileOrigin.position, Quaternion.LookRotation(povOrigin.forward));
    projectile.transform.localScale = Vector3.one * 5f; 
    projectile.GetComponent<Rigidbody>().AddForce(povOrigin.forward * 25f, ForceMode.Impulse);

}

}

}

