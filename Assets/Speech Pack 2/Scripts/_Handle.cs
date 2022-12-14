using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using UnityEngine.Video;
 
//Custom 8


public partial class Wit3D : MonoBehaviour {

	public Text myHandleTextBox;
    private bool actionFound;
	private string theScene;
  

	void showMsg(){
		myHandleTextBox.text = "Sorry, that action is unavailable for this model.";
	}

	void Handle (string jsonString) {
 
		if (jsonString != null) {

			RootObject theAction = new RootObject ();
			JsonConvert.PopulateObject (jsonString, theAction);
			//option 1
            if (theAction.entities.play != null) {
  					if(theAction._text.Contains("play")){
     					
                    }else{
                        showMsg();
                    }
 					actionFound = true;
 			}

			//option 2
            if (theAction.entities.stop != null) {
 					if (theAction._text.Contains ("stop")) {
 
                    }else{
                        showMsg();
                    }
 					actionFound = true;
 			}

            if (theAction.entities.remove != null || theAction.entities.replace != null) {
                     if (theAction._text.Contains ("remove") || theAction._text.Contains("replace")) {
                         if (theAction._text.Contains("roof")){
                            houseScript.instance.toggleRoof();
                         }else{
                            showMsg();
                         }
 					}
 					actionFound = true;
 			}

 
            if (theAction.entities.show != null || theAction.entities.hide != null) {
                     if (theAction._text.Contains("second floor")){
                            houseScript.instance.toggleSecondFloor();
                            Debug.Log("Toggling Second Floor");
                     }
                actionFound = true;
             }


            if (theAction.entities.daytime != null) {
                if (theAction._text.Contains("daytime") || theAction._text.Contains("day time")) {
                    houseScript.instance.toggleDayNight();
                    Debug.Log("Toggling Day Night");
                }
                actionFound = true;
            }


            if (theAction.entities.nighttime != null) {
                if (theAction._text.Contains("nighttime") || theAction._text.Contains("night time")) {
                    houseScript.instance.toggleDayNight();
                    Debug.Log("Toggling Day Night");
                }
                actionFound = true;
            }
 
            if (!actionFound) {
				myHandleTextBox.text = "Request unknown, please ask a different way.";
			}

 		}//END OF IF

 	}//END OF HANDLE VOID

}//END OF CLASS
	

//Custom 9
public class Play {
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}
 
public class Stop {
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}

public class Remove {
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Replace {
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Show {
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Hide {
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}


public class Daytime {
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Nighttime {
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Entities {
    public List<Play> play { get; set; }
	public List<Stop> stop { get; set; }
	public List<Remove> remove { get; set; }
	public List<Replace> replace { get; set; }
    public List<Show> show { get; set; }
    public List<Hide> hide { get; set; }
    public List<Daytime> daytime { get; set; }
    public List<Nighttime> nighttime { get; set; }
}

public class RootObject {
	public string _text { get; set; }
	public Entities entities { get; set; }
	public string msg_id { get; set; }
}