using System.Collections;
//The base class for modular programming.
// represents one block of code that can be
// moved around in the instruction inventory.
//	Function and Return are important special subclasses of this.

//  Will have many other subclasses to encompass the range of actions we
//	want to be possible.

public abstract class Instruction {
	public string name = "instruction";
	//public Icon icon;
	//public Sound runSound;
	//etc.
	
	private string[] requiresChannelTypes = {null,null,null};
	
	// Runs this instruction on the bot.
	// should be overridden by subclasses. 
	//	returns the amount of time before the bot should run Step() again.
	public abstract float run(Core_Bot_Basic bot);
	
	// checks if the bot's channel var types match the requirements of this instruction.
	// subClasses that have channel requirements should check this first, and return or 
	// explode or something if the requirements are not met.
	public bool checkChannelRequirements(Core_Bot_Basic bot){
		for(int i=0; i<3; i++){
			if( requiresChannelTypes[i] != null)
				if (string.Compare(requiresChannelTypes[i], bot.processor.channels[i].type) != 0)
					return false;
		}
		return true;
	}
	
	/*
	public virtual int recursiveLength(){
		return 1;	
	}
	//*/
	
}
