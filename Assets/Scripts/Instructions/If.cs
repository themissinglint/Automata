using UnityEngine;
using System.Collections;

// Subclass of Instruction that makes a bot go stop.
public class If : Instruction {
	Instruction left, right;
	Operation operation;
	
	public override float run(Core_Bot_Basic bot){
		// if the condition fails, abort this function:
		if( ! operation.operation(left, right))
		{
			bot.processor.callStack.Pop ();	
			return 1f;
		}
		// if the condition is true, do nothing.
		return .5f;
	}
}
