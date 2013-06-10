using UnityEngine;
using System.Collections.Generic;

//	A game object's processor is responsible for translating basic game actions into the units core commands (it's hardware interface).
//  Applied to a game entity, it sends commands to the entities core.
//  Has a main_function that makes it do things. An instruction from the main_function gets called every Step().
public class Processor_Bot_Basic{
    private Function main_function;	// when the callstack is empty, the processor starts running this.
    private float timeToNextStep;	// how much time before Step() is run again.
	private Core_Bot_Basic bot;		// reference to the physical bot this is the processor of.
	
	public BotVariable[] channels = new BotVariable[3]; // channels hold bot's variables and may be set by incoming signals.
    public Stack<Frame> callStack;		// the stack of functions this processor is running.

    // Use this for initialization
    public Processor_Bot_Basic(Core_Bot_Basic owner, Function root){
        callStack = new Stack<Frame>();
        main_function = root;
        timeToNextStep = 0;
		bot = owner;
    }

    // Update is called once per frame
    public void Update(){
        timeToNextStep -= Time.deltaTime;
        if (timeToNextStep <= 0){
            timeToNextStep = Step();
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // run the next instruction in my main_function (which maybe a nested one).
    //		returns the time until Step() should be called again.
    float Step(){

        if (callStack.Count == 0){
            // last step we finished our root function.
            // start it up again!
            //	(later there could be more maintainance here)
            callStack.Push(new Frame(main_function));
        }

        // get the current frame:
        Frame curFrame = callStack.Peek();
				
        // get the current instruction in this frame's function:
        Instruction curInstruction = curFrame.function.subInstructions[curFrame.instructionPointer];

        // increment the frame's instructionPointer to the next code block in its function
        //	(we increment the counter BEFORE running the instruction)
        curFrame.instructionPointer++;
		
		BotVariable param = curInstruction.param;
		float fParam;
		Vector3 v3Param;
        // run this instruction!:
		switch (curInstruction.type){
			case InstructionType.Return:
				callStack.Pop ();
				return 1F;
			break;
			case InstructionType.If:
				//TODO, requires conditionals.
				return 0F;
			break;
			case InstructionType.Throttle:
				fParam = FloatFromBotVariable(curInstruction.param);
				if(fParam != Mathf.NegativeInfinity){
					bot.SetThrottle(fParam);
					return 1F;
				}
			break;
			case InstructionType.Break:
				fParam = FloatFromBotVariable(curInstruction.param);
				if(fParam != Mathf.NegativeInfinity){
					bot.SetBreak(fParam);
					return 1F;
				}
			break;
			case InstructionType.TurnTo:
				v3Param = LocationFromBotVariable(curInstruction.param);
				if(v3Param != null){
					bot.TurnToward(v3Param, 2);
					return 1F;
				}
				
			break;
			case InstructionType.While:
				//////TODO, requires conditionals.
				/*
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
				//*/				
			break;
			default:
				Debug.LogError ("Unexpected instruction type!");
			break;
		}
    }
	
	// If a param is a location, return that.  If the param is a channel
	// with a location in it, return that location.  Otherwise fail.
	private Vector3 LocationFromBotVariable(BotVariable data){
		if( data.type == DataType.Location )
			return data.location;
		if( data.type == DataType.Channel )
			if (channels[data.channel].type == DataType.Location)
				return channels[data.channel].location;
			else{
				Debug.Log("bot referenced a channel of the wrong type!");
				// should stall or explode or something.
			}
		return null;
	}
	
	
	// If a param is a float, return that.  If the param is a channel
	// with a float in it, return that float.  Otherwise fail.
	private float FloatFromBotVariable(BotVariable data){
		if( data.type == DataType.Float )
			return data.floatValue;
		if( data.type == DataType.Channel )
			if (channels[data.channel].type == DataType.Float)
				return channels[data.channel].floatValue;
			else{
				Debug.Log("bot referenced a channel of the wrong type!");
				// should stall or explode or something.
			}
		return Mathf.NegativeInfinity;
	}
}