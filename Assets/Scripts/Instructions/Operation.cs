

// Subclass of Instruction that makes a bot go forward.
public abstract class Operation : Instruction {
	
	// throttle forward at 50.
	public override float run(Core_Bot_Basic bot){
		return 0f;
	}
	
	public abstract bool operation(Instruction left, Instruction right);
	
}
