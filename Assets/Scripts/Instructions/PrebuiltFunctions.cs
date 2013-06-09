using UnityEngine;
using System.Collections;

public class PrebuiltFunctions{
	
	public static Instruction inst_Return, inst_Forward50, inst_TurnTowardsA, inst_ApplyBreaks;
	public static Function driveToA, justDrive;//, driveToAThenB;
	
	public static void init(){
		inst_Return = new Return();
		inst_Forward50 = new Forward50();
		inst_TurnTowardsA = new TurnTowardsA();
		inst_ApplyBreaks = new ApplyBreaks();
		
		driveToA = new Function();
		driveToA.name = "drive to A";
		driveToA.subInstructions.Add(inst_TurnTowardsA);
		driveToA.subInstructions.Add(inst_Forward50);
		driveToA.subInstructions.Add(inst_Return);
		
		justDrive = new Function();
		justDrive.name = "just drive";
		justDrive.subInstructions.Add(inst_Forward50);
		justDrive.subInstructions.Add(inst_Return);
		
		Debug.Log("PrebuiltFunctions prebuilt!");
		/*
		driveToAThenB = new Function();
		driveToA.subInstructions.Add(TurnTowardsA);
		driveToA.subInstructions.Add(Forward50);
		driveToA.subInstructions.Add(Return);
		//*/
	}
}
