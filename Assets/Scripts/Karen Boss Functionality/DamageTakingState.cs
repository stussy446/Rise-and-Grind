using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTakingState : IKarenState
{
    public void Idling(IKarenContext context)
    {
    }


    public void Moving(IKarenContext context)
    {
        Debug.Log("transitioning from DamageTaking State to Moving state");
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
        Debug.Log("transitioning from DamageTaking State to Dying state");
        context.SetState(new DyingState());
    }
}
