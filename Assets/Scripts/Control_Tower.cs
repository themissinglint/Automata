using UnityEngine;
using System.Collections.Generic;

public class Control_Tower : MonoBehaviour {
	private int nextClickSendsOnChannel = -1; //-1 is sentinal for this is inactive.
	public float signalStrength = 75;		// bots within this distance of the tower get the signal.
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		if (nextClickSendsOnChannel != -1){
			if (Input.GetMouseButtonDown(0)){
				
				//get the point clicked:
				RaycastHit hit = GPS.getRaycastHitFromScreenPos(Camera.main.ScreenToViewportPoint(Input.mousePosition));
				Vector3 location = hit.point;
				
				//build the message:
				BotVariable data = new BotVariable();
				data.Set (location);
				
				//send the message:
				SendSignal(transform.position, signalStrength, nextClickSendsOnChannel, data);	
				
				//reset self:
				nextClickSendsOnChannel = -1;
			}
		}		
	}
	
	// Send a signal to all bots within range.
	// The bots all get thier .processor.channels[channel] = data;.
	// This should eventually get moved out of control tower into some more global place.
	private void SendSignal(Vector3 origin, float strength, int channel, BotVariable data){
		Debug.Log ("Control Tower sending signal.");
		
		// get the list of bots from Factory:
		List<Core_Bot_Basic> bots = Factory.bots;
		
		//for each bot, if it's in range:
		for(int i = 0; i < bots.Count; i++){
			Core_Bot_Basic bot = bots[i];
			if ( Vector3.Distance(origin, bot.transform.position) < strength){
				// set the data to the selected channel:
				bot.processor.channels[channel] = data;	
				Debug.Log ("signal recieved by bot");
			}
		}
	}
	
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,150,150), "Control Tower");

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,120,20), "Set Location A")) {
			nextClickSendsOnChannel = 0;
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(20,70,120,20), "Set Location B")) {
			nextClickSendsOnChannel = 1;
		}
		
		// Make the third button.
		if(GUI.Button(new Rect(20,100,120,20), "Set Location C")) {
			nextClickSendsOnChannel = 2;
		}
	}

}
