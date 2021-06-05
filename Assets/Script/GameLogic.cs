using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct LogicSfx{
public AudioClip[] l_sfx;
}
public class GameLogic : MonoBehaviour
 
{
    public Question[] questions;
    private AudioSource l_audio;
    public GameObject canvas;
    public GameObject gameover;
    public LogicSfx logicSfx;
    public static bool gameEnd=false;
    public static bool isBnt=false;
    private float deltaTime=10;
    public Text timeText;
    public Text misson;
     private float done = 7.0F; 
    public Animator animator;
    public bool isclick;
     int i=0;
    void Start(){
        l_audio=GetComponent<AudioSource>();
        canvas.SetActive(true);
        StartCoroutine(Delay());
        sound(i);
        isBnt=true;
    }

    void Update(){
 if(done>0F){
   done-=Time.deltaTime;
   timeText.text = "남은 시간 : "+(int)done;
   Quiz(i);
   FireCtrl.canMove=false;
    }

    else{
        gameEnd=true;
        
        gameEndShow();
    }
    if(Input.GetKeyDown(KeyCode.R)&&isBnt==true){
        
        done=7f;
        i++;
        sound(i);
        isclick=true;
    }
    else{
        isclick=false;
    }
    animator.SetBool ( "click" ,isclick);
    if(Input.GetMouseButtonDown(0)){
        gameEnd=true;
        gameEndShow();
        isBnt=false;
    }

 }




 void sound(int value){
        var l_sfx= logicSfx.l_sfx[value];
        l_audio.PlayOneShot(l_sfx);
 }
 IEnumerator Delay(){
    yield return new WaitForSeconds(90);
 }
 public void Quiz(int i){
     misson.text=questions[i].fact;
 }
//버튼 눌림
 public void btn(){
    
   
    
    
    
    
 }

 public void gameEndShow(){
gameover.SetActive(true);

 }
}
