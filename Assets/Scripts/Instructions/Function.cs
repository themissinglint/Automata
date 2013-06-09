using System.Collections.Generic;

// A Function is a special subclass of Instruction that 
// 	contains other Instructions.
//	Its run adds itself to the calling bot's callStack.

public class Function : Instruction {
	public List<Instruction> subInstructions;
		
	public Function(){
		subInstructions = new List<Instruction>();	
	}
	
	// When a function is run, it pushes itself onto the
	// bot's callstack.
	public override float run(Core_Bot_Basic bot){
		bot.processor.callStack.Push(new Frame(this));
		return 0;
	}
		
	// how many code blocks are in this function?
	public int length(){
		return subInstructions.Count;	
	}
	
	/*
	// recursively calculate the length of all my sub-instructions.
	public int recursiveLength(){
		int len = 0;
		for (int i = 0; i < subInstructions.Count; i++){
			len += subInstructions[i].recursiveLength();
		}
		return len;
	}
	//*/		
}
