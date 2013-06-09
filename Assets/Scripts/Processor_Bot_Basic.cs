using UnityEngine;
using System.Collections.Generic;

//	A game object's processor is responsible for translating basic game actions into the units core commands (it's hardware interface).
//  Applied to a game entity, it sends commands to the entities core.
//  Has a rootFunction that makes it do things. An instruction from the rootFunction gets called every Step().
public class Processor_Bot_Basic
{
    private Function rootFunction;
    private float timeToNextStep;


    public Function root;
    public Transform t_planet;
    public Stack<Frame> callStack;

    // Use this for initialization
    void Start()
    {
        callStack = new Stack<Frame>();
        rootFunction = root;
        timeToNextStep = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeToNextStep -= Time.deltaTime;
        if (timeToNextStep <= 0)
        {
            timeToNextStep = Step();
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // run the next instruction in my rootFunction (which maybe a nested one).
    //		returns the time until Step() should be called again.
    float Step()
    {

        if (callStack.Count == 0)
        {
            // last step we finished our root function.
            // start it up again!
            //	(later there could be more maintainance here)
            callStack.Push(new Frame(rootFunction));
        }

        // get the current frame:
        Frame curFrame = callStack.Peek();

        // get the current instruction in this frame's function:
        Instruction curInstruction = curFrame.function.subInstructions[curFrame.instructionPointer];

        // increment the frame's instructionPointer to the next code block in its function
        //	(we increment the counter BEFORE running the instruction)
        curFrame.instructionPointer++;

        // run this instruction!:
        return curInstruction.run(this);
    }
}