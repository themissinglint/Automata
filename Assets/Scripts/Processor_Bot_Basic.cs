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

        // run this instruction!:
        return curInstruction.run(bot);
    }
}