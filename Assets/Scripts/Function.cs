using UnityEngine;
using System.Collections.Generic;

// A Function is a special subclass of Instruction that 
// 	contains other Instructions.
//	Its run adds itself to the calling bot's callStack.

public class Function : Instruction {
	public List<Instruction> subInstructions;
		
	//Constructor.  
	//That weird syntax overrides the default base class constructor call.
	public Function() : base(InstructionType.Function){
		subInstructions = new List<Instruction>();	
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

	public static Function 
			DRIVE_TOWARDS_A = new Function(),
			DRIVE_TOWARDS_B = new Function(),
			DRIVE_TOWARDS_C = new Function();
	
	public static void init(){
		DRIVE_TOWARDS_A.subInstructions.Add(Instruction.TURN_TOWARDS_A);
		Debug.Log("DRIVE_TOWARDS_A.subInstructions[0].param.channel is " + DRIVE_TOWARDS_A.subInstructions[0].param.channel);
		DRIVE_TOWARDS_A.subInstructions.Add(Instruction.FORWARD_30);
		DRIVE_TOWARDS_A.subInstructions.Add(Instruction.RETURN);
	}
}
