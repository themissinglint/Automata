

// Subclass of Instruction that makes a bot go stop.
public class ApplyBreaks : Instruction {
	
	public override float run(Core_Bot_Basic bot){
		
		bot.SetBreaks(20F);
		
		return .5f;
	}
}
