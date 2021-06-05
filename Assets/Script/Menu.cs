using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    
    public Slider mouseSens;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text=""+mouseSens.value;
    }

    public void youngjumScene(){
        SceneManager.LoadScene("youngjum");
    }
    public void realScene(){
        SceneManager.LoadScene("real");
    }
    public void setting(){
       
    }
    public void exit(){
       Application.Quit();
    }

      public void setMouseSens(float mouse)

    {

        mouseSens.value = mouse;

    }
    
}
