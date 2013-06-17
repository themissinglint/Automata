using UnityEngine;

public enum DataType {Uninitialized, Location, Float, String, Channel};

public class BotVariable{
	public DataType type;
	public Vector3 location;
	public float floatValue;
	public int channel;
	public string name;
	
	public BotVariable(){
		type = DataType.Uninitialized;	
	}
	
	// Constructors for each type:
	public BotVariable(string newName){
		type = DataType.String;
		name = newName;
	}
				
	public BotVariable(float value){
		type = DataType.Float;
		floatValue = value;
	}
	
	public BotVariable(int value){
		if( value < 0 || value > 2)
			Debug.LogError("BotVariable with invalid channel ID: " + value);
		type = DataType.Channel;
		channel = value;
	}	
	
	public BotVariable(Vector3 loc){
		type = DataType.Location;
		location = loc;
	}
	
	// Sets for each type:
	
	public void Set(string newName){
		type = DataType.String;
		name = newName;
	}
				
	public void Set(float value){
		type = DataType.Float;
		floatValue = value;
	}
	
	public void Set(int value){
		if( value < 0 || value > 2)
			Debug.LogError("BotVariable with invalid channel ID:" + value);
		type = DataType.Channel;
		channel = value;
	}	
}
