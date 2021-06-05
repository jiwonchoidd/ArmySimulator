using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

    public struct PlayerSfx{
        public AudioClip[] fire;
    }
public class FireCtrl : MonoBehaviour
{
    
    public GameObject bullet;
    public Transform firePos; 
    private ParticleSystem muzzleFlash;
    private AudioSource _audio;
    public PlayerSfx playerSfx;
    public GameObject muzzlelight;
    private Light mLight;
    public float lightDuration;
    public Animator animator;
    private bool isZoom = false;
    private bool isShoot = false;
    public GameObject weaponCamera;
    //public GameObject scopeOverlay;
    public Camera mainCamera;
    private float scopeFOV=15f;
    private float normalFOV;

    //안움직이게 하는 변수임 이거 트루로 하면 움직임
    public static bool canMove=true;

    // Start is called before the first frame update
    void Start()
    {
        //FirePos 하위에 있는 컴포넌트를 추출
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();
        _audio=GetComponent<AudioSource>();
        mLight= firePos.GetComponentInChildren<Light>();
        mLight.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&canMove!=false){// 마우스 왼쪽 클릭
            fire();
            TurnLightOn();
            //isShoot=!isShoot;
           // animator.SetBool("shoot", isShoot);
            
        }
     
       if(Input.GetMouseButtonDown(1)&&canMove!=false){// 마우스 오른쪽 클릭
           isZoom=!isZoom;
           Zoomsfx();
           animator.SetBool("zoom", isZoom);
           if(isZoom){
               StartCoroutine(OnScoped());
           }
           else
           OnUnScoped();
        }

        
    }
    void fire(){
        Instantiate(bullet,firePos.position,firePos.rotation);//총알발사
        muzzleFlash.Play();//총구 화염
        FireSfx();
    }
    void FireSfx(){
        var _sfx= playerSfx.fire[0];
        _audio.PlayOneShot(_sfx,1.0f);
    }

    void Zoomsfx(){
         var _sfx= playerSfx.fire[1];
        _audio.PlayOneShot(_sfx,1.0f);
    }
  private void TurnLightOn() {
         StartCoroutine(ActivateLight());
     }

    private IEnumerator ActivateLight(){
        mLight.enabled=true;
        yield return new WaitForSeconds(lightDuration);
        mLight.enabled=false;
    }

    IEnumerator OnScoped(){
        yield return new WaitForSeconds(.3f);
        //scopeOverlay.SetActive(true);
        //weaponCamera.SetActive(false);
        normalFOV=mainCamera.fieldOfView;
         mainCamera.fieldOfView=scopeFOV;
    }
    void OnUnScoped(){
       // scopeOverlay.SetActive(false);
       // weaponCamera.SetActive(true);
        mainCamera.fieldOfView=normalFOV;
    }

}
   
