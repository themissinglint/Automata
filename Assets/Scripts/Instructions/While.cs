using System.Collections.Generic;

// Subclass of Instruction that makes a bot go stop.
public class While : Instruction {
	Instruction left, right;
	Operation operation;
	
	public override float run(Core_Bot_Basic bot){
		// if the condition fails, abort this function:
		if( ! operation.operation(left, right))
		{
			bot.processor.callStack.Pop ();	
			return 1f;
		}
		// if the condition is true, make a new frame with this function, 
		// add it to the top of the callStack with the instruction pointer 
		// pointing AFTER the while.  Then move this frame's instruction pointer
		// to point at this while again.  Result should be that it runs a dummy 
		// copy of this function, then returns to check this while again.
		else {
			Frame thisFrame = bot.processor.callStack.Peek();
			bot.processor.callStack.Push(new Frame(thisFrame.function));
			bot.processor.callStack.Peek().instructionPointer++;
			thisFrame.instructionPointer--;
			return .5f;
		}
	}
}
