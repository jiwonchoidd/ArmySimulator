using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
     public float SpeedH = 10f;
     public float SpeedV = 10f;
 
     private float yaw = 0f;
     private float minyaw = -10f;
     private float maxyaw = 8f;
     private float pitch = 0f;
     private float minPitch = -5f;
     private float maxPitch = 4f;

        //반동  조절 
    public float upRecoil;
    public float sideRecoil; 

// 숨을 쉽니까?
    Vector3 startPos;
    public float amplitude = 10f;
    public float period = 5f;
    public bool isBreath=true;
    private void Start(){
    startPos = transform.position;
    }
     void Update()
     {
         CameraRotate();
         if(Input.GetMouseButtonDown(0)&& FireCtrl.canMove!=false){// 마우스 왼쪽 클릭
           AddRecoil(0.6f,-0.1f); 
         }
         if(isBreath==true){
        float theta = Time.timeSinceLevelLoad / period;
        float distance = amplitude * Mathf.Sin(theta);
        transform.position = startPos + Vector3.up * distance;
        }
   }
     
     void CameraRotate() {
         yaw += Input.GetAxis("Mouse X") * SpeedH+ sideRecoil;
         pitch -= Input.GetAxis("Mouse Y") * SpeedV+ upRecoil;
         pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
         yaw = Mathf.Clamp(yaw, minyaw, maxyaw);
         sideRecoil=0;
         upRecoil=0;
        
         transform.eulerAngles = new Vector3(pitch, yaw, 0f);
         
     }

     

      public void AddRecoil(float up, float side){
        sideRecoil +=side;
        upRecoil+=up;
    }

    //숨쉬는 카메라 흔들림
    

}
