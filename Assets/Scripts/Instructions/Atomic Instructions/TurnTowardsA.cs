using UnityEngine;

// Subclass of Instruction that makes a bot go stop.
public class TurnTowardsA : Instruction {
	private string[] requiresChannelTypes = {"Location",null,null};
	
	
	public override float run(Core_Bot_Basic bot){
		if( ! checkChannelRequirements(bot) ){
			Debug.Log("Bot has bad channel data for this function!"); 
			return 3F;
		}
		bot.TurnToward(bot.processor.channels[0].location, 2F);
		return 1F;
	}
}