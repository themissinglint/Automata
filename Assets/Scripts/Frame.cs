
// The frame class is used to hold a call stack frame for a bot.
// it holds an Function, an instructionPointer, and any other variables
// needed to track the execution of an Function.
public class Frame {
	public Function function;
	public int instructionPointer;
	
	//makes a new Frame with the given Function
	// and instructionPointer = 0.
	public Frame(Function fn){
		instructionPointer = 0;
		function = fn;
	}
}
