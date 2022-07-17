using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : IKarenState
{
    public void Idling(IKarenContext context)
    {
    }


    public void Moving(IKarenContext context)
    {
        Debug.Log("transitioning from Attacking State to Moving state");
        context.SetState(new MovingState());
    }


    public void Attacking(IKarenContext context)
    {
    }


    public void DamageTaking(IKarenContext context)
    {
        Debug.Log("transitioning from Attacking State to DamageTaking state");
        context.SetState(new MovingState());
    }


    public void Dying(IKarenContext context)
    {
        Debug.Log("transitioning from Attacking State to Dying state");
        context.SetState(new MovingState());
    }
}
