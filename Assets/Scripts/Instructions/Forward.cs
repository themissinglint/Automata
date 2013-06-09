

// Subclass of Instruction that makes a bot go forward.
public class Forward : Instruction {

	// Runs Forward on the bot.
	public override float run(Bot bot){
		
		Bot.positionGoal = bot.position + bot.transform.forward * 20;
		
		return 3f;
	}
}