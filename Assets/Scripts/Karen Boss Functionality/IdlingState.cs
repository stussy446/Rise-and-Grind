using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlingState : IKarenState
{
    public void Idling(IKarenContext context)
    {
    }


    public void Moving(IKarenContext context)
    {
        Debug.Log("transitioning from Idling State to Moving state");
        context.SetState(new MovingState());
    }


    public void Attacking(IKarenContext context)
    {
    }


    public void DamageTaking(IKarenContext context)
    {
    }


    public void Dying(IKarenContext context)
    {
    }

}
