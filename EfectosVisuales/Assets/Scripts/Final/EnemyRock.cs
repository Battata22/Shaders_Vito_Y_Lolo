using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRock : EnemyBase
{
    protected override void Start()
    {
        base.Start();
        type = EnemyType.Rock;
    }

    void ParticulasMuerte()
    {
        print("Particulas " + gameObject.name);
    }

    void AudioMuerte()
    {
        print("Audio " + gameObject.name);
    }

    protected override void meMuero()
    {
        base.meMuero();
        ParticulasMuerte();
        AudioMuerte();
        ParticulasMuerte();
        AudioMuerte();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            EntityManager.instance.player.GetDamage(damage);
        }
    }
}
