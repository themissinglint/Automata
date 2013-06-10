using UnityEngine;

enum DataType {Location, Float, String, Channel};

public class BotVariable{
	public DataType type;
	public Vector3 location;
	public float floatValue;
	public int channel;
	public string name;
	
	public void Set(Vector3 loc){
		type = DataType.Location;
		location = loc;
	}
			
	public void Set(string newName){
		type = DataType.String;
		name = newName;
	}
				
	public void Set(float value){
		type = DataType.Float;
		floatValue = value;
	}
	
	public void Set(int value){
		type = DataType.Channel;
		channel = value;
	}	
}
