using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
   
    
    private void OnCollisionEnter(Collision coll){
        if(coll.collider.tag=="BULLET"){
            Destroy(coll.gameObject);
           
        }
    }
  
   
}
