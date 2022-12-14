using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class vbButton : MonoBehaviour 
{
    public GameObject[] myButtons;
    public GameObject confirmPanel;
    public GameObject videoPlane;
    private bool isVideoPlaying = false;
    private VideoPlayer video;  
    


    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<myButtons.Length; i++){
            myButtons[i].GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
            myButtons[i].GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonReleased);
        }
        video =videoPlane.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb){
        if(vb.name == "buttonT3"){
            confirmPanel.SetActive(true);
        }
        if(vb.name == "buttonT1Start" && isVideoPlaying==false){
            video.Play();
            isVideoPlaying=true;
        }
        if(vb.name == "buttonT1Stop" && isVideoPlaying==true){
            video.Stop();
            isVideoPlaying=false;
        }

        if(vb.name =="removeRoof"){
            vb.gameObject.SetActive(false);
            myButtons[4].SetActive(true);
            houseScript.instance.toggleRoof();
        }
        if(vb.name =="replaceRoof"){
            vb.gameObject.SetActive(false);
            myButtons[3].SetActive(true);
            houseScript.instance.toggleRoof();
        }
        if(vb.name =="removesecondFloor"){
            vb.gameObject.SetActive(false);
            myButtons[6].SetActive(true);
            houseScript.instance.toggleSecondFloor();
        }
        if(vb.name =="replacesecondFloor"){
            vb.gameObject.SetActive(false);
            myButtons[5].SetActive(true);
            houseScript.instance.toggleSecondFloor();
        }
        if(vb.name =="Daytime"){
            vb.gameObject.SetActive(false);
            myButtons[8].SetActive(true);
            houseScript.instance.toggleDayNight();
        }
        if(vb.name =="Nighttime"){
            vb.gameObject.SetActive(false);
            myButtons[7].SetActive(true);
            houseScript.instance.toggleDayNight();
        }
    }
    
    public void OnButtonReleased(VirtualButtonBehaviour vb){
        
    }
}
