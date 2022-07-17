using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarenStatePattern : MonoBehaviour, IKarenContext
{
    IKarenState currentState = new IdlingState();

    public void Moving() => currentState.Moving(this);

    public void Attacking() => currentState.Attacking(this);

    public void DamageTaking() => currentState.DamageTaking(this);

    public void Dying() => currentState.Dying(this);

    void IKarenContext.SetState(IKarenState newState)
    {
        currentState = newState;
    }

}
