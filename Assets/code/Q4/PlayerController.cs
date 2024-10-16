using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 


namespace Q4 {
public class PlayerController : MonoBehaviour {
    public static PlayerController instance; 
    
    public List<int> keyIdsObtained; 
    void Awake()
    {
        instance = this; 
        keyIdsObtained = new List<int>();
    }

    // Update is called once per frame
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
}
}
}

}
