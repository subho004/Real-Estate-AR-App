using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void changeScene(string name){
        SceneManager.LoadSceneAsync(name);
    }

    public void Quit(){
        Application.Quit();
    }

    public void hideObj(string name){
        GameObject.Find(name).SetActive(false);
    }
}
