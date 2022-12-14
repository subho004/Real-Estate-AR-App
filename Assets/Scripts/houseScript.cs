using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseScript : MonoBehaviour
{

    public GameObject theRoof;
    public GameObject[] secondFloor;
    public GameObject[] theLights;
    public GameObject directionalLight;

    private bool daytime = true;

    public static houseScript instance;

    private void Awake(){
        if(instance==null){
            instance=this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleRoof(){
        if(theRoof.activeInHierarchy){
            theRoof.SetActive(false);
        }else{
            theRoof.SetActive(true);
        }
    }

    public void toggleSecondFloor(){
        toggleRoof();  //only if we want to toggle off the roof too
        for(int i=0; i<secondFloor.Length; i++){
            if(secondFloor[i].activeInHierarchy){
                secondFloor[i].SetActive(false);
            }else{
                secondFloor[i].SetActive(true);
            }
        }
    }

    public void toggleDayNight(){
        if(daytime){
            for(int i=0; i<theLights.Length; i++){
            if(theLights[i].activeInHierarchy){
                theLights[i].SetActive(true);
            }
          }
          directionalLight.GetComponent<Light>().color=new Color32(11, 23 , 46, 255);
          daytime=false;
        }else{
             for(int i=0; i<theLights.Length; i++){
            if(theLights[i].activeInHierarchy){
                theLights[i].SetActive(false);
            }
          }
          directionalLight.GetComponent<Light>().color=new Color32(255, 255 , 255, 255);
          daytime=true;
        }
    }
}
