/// <summary>
/// interface for all of the states that the Karen boss can enter during boss fight
/// </summary>
public interface IKarenState
{
    void EnterState(IKarenContext context);
    void OnCollisionEnter(IKarenContext context);

    void Idling(IKarenContext context);
    void Moving(IKarenContext context);
    void Attacking(IKarenContext context);
    void DamageTaking(IKarenContext context);
    void Dying(IKarenContext context);

}


