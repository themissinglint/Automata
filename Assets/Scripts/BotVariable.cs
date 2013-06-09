using UnityEngine;
public class BotVariable{
	public string type;
	public Vector3 location;
	public float floatValue;
	public string name;
	
	public void Set(Vector3 loc){
		type = "location";
		location = loc;
	}
			
	public void Set(string newName){
		type = "string";
		name = newName;
	}
				
	public void Set(float value){
		type = "float";
		floatValue = value;
	}
}
