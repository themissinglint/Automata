using System.Collections;
//The base class for modular programming.
// represents one block of code that can be
// moved around in the instruction inventory.
//	Function and Return are important special subclasses of this.

//  Will have many other subclasses to encompass the range of actions we
//	want to be possible.

enum InstructionType {Return, If, While, Throttle, Break, TurnTo, };

public abstract class Instruction {
	
	public InstructionType type;
	public string name = "instruction";
	//public Icon icon;
	//public Sound runSound;
	//etc.	
	
	public BotVariable param = null;
	
	public Instruction(InstructionType type, BotVariable param){
		this.type = type;
		this.param = param;
	}
	
	private string[] requiresChannelTypes = {null,null,null};
	
	// Runs this instruction on the bot.
	//	returns the amount of time before the bot should run Step() again.
	public float run(Core_Bot_Basic bot){
		return myRun(this, bot);	
	}
	
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
	
	public static Instruction 
					FORWARD_50 = Instruction(run_forward, 50),
					FORWARD_30 = Instruction(run_forward, 30),
					FORWARD_10 = Instruction(run_forward, 10),
					TURN_TOWARDS_A = Instruction(run_turnTowards, 0),
					TURN_TOWARDS_B = Instruction(run_turnTowards, 1),
					TURN_TOWARDS_C = Instruction(run_turnTowards, 2),
					MINE = Instruction(run_mine);
	
}
