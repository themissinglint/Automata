
//The base class for modular programming.
// represents one block of code that can be
// moved around in the instruction inventory.
//	Function and Return are important special subclasses of this.

//  Will have many other subclasses to encompass the range of actions we
//	want to be possible.

public abstract class Instruction {
	//public Icon icon;
	//public Sound runSound;
	//etc.
	
	// Runs this instruction on the bot.
	// should be overridden by subclasses. 
	//	returns the amount of time before the bot should run Step() again.
	public abstract float run(Core_Bot_Basic bot);
	
	/*
	public virtual int recursiveLength(){
		return 1;	
	}
	//*/
	
}
