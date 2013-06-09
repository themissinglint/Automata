
// A special subclass of Instruction that returns from a Function.
//	later we may want variants that actually return a value, or 
//	maybe that will be stored on the bot as a global somehow.

public class Return : Instruction {

	// Runs return on the bot.
	public override float run(Bot bot){
		// remove the current frame from the bot's callstack
		bot.callStack.Pop();
		return 0;
	}
}
