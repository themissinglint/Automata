

// Subclass of Instruction that makes a bot go forward.
public class Forward50 : Instruction {
	
	// throttle forward at 50.
	public override float run(Core_Bot_Basic bot){
		
		bot.SetThrottle(50);
		
		return 1f;
	}
}