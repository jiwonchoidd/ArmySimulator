using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet1 : MonoBehaviour
{
    public GameObject sparkEffect;
    
    private void OnCollisionEnter(Collision coll){
        if(coll.collider.tag=="BULLET"){
            Destroy(coll.gameObject);
            ShowEffect(coll);
        }
    }
    void ShowEffect(Collision coll){
        ContactPoint contact=coll.contacts[0];

        Quaternion r=Quaternion.FromToRotation(-Vector3.forward, contact.normal);

        Instantiate(sparkEffect,contact.point,r);
    }
   
}
