using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLightbulb : MonoBehaviour
{
   public void Interact(){
        gameObject.SetActive(!gameObject.activeSelf);
   }
}
