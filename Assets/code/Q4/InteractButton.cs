using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Q4{

public class InteractButton : MonoBehaviour
{
    public GameObject interactionTarget; 
    
    public void Interact() {
        if(interactionTarget != null){
            DoorCode targetDoor = interactionTarget.GetComponent<DoorCode>();
            if(targetDoor != null){
                targetDoor.Interact(gameObject);
    }

    InteractLightbulb targetLight = interactionTarget.GetComponent<InteractLightbulb>();
    if(targetLight){
        targetLight.Interact();
    }
}
    }
}
}