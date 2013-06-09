

// Subclass of Instruction that makes a bot turn left 90 degrees.
public class TurnLeft90 : Instruction {

	// Runs return on the bot.
	public override float run(Bot bot){
		// remove the current frame from the bot's callstack
		bot.callStack.Pop();
		return 0;
	}
}