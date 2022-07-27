using System.Collections;


public interface ILifeSystem
{
    void Die();

    void TakeDamage();

    IEnumerator DeathSequence();
}
