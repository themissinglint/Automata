using System.Collections;
//The base class for modular programming.
// represents one block of code that can be
// moved around in the instruction inventory.
//	Function and Return are important special subclasses of this.

//  Will have many other subclasses to encompass the range of actions we
//	want to be possible.

public enum InstructionType {Return, If, While, Throttle, Break, TurnTo, Function};

public class Instruction {
	
	public InstructionType type;
	public string name = "instruction";
	//public Icon icon;
	//public Sound runSound;
	//etc.	
	
	public BotVariable param = null;
	
	public Instruction(InstructionType type, BotVariable param = null){
		this.type = type;
		this.param = param;
	}
	
	/*
	private string[] requiresChannelTypes = {null,null,null};
		
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
	//*/
	
	public static Instruction 
					FORWARD_50 = new Instruction(InstructionType.Throttle, new BotVariable(50F)),
					FORWARD_30 = new Instruction(InstructionType.Throttle, new BotVariable(30F)),
					FORWARD_10 = new Instruction(InstructionType.Throttle, new BotVariable(10F)),
					TURN_TOWARDS_A = new Instruction(InstructionType.TurnTo, new BotVariable(0)),
					TURN_TOWARDS_B = new Instruction(InstructionType.TurnTo, new BotVariable(1)),
					TURN_TOWARDS_C = new Instruction(InstructionType.TurnTo, new BotVariable(2)),
					RETURN = new Instruction(InstructionType.Return);
	
}
