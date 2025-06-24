using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : EnemyBase
{
    protected override void Start()
    {
        base.Start();
        type = EnemyType.Fire;
    }

   void ParticulasMuerte()
   {
        print("Particulas " + gameObject.name);
   }

    void AudioMuerte()
    {
        print("Audio " + gameObject.name);
    }

    protected override void OnDestroy()
    {
        meMuero += ParticulasMuerte;
        meMuero += AudioMuerte;
        base.OnDestroy();
        meMuero -= ParticulasMuerte;
        meMuero -= AudioMuerte;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            PostProcessManager.instance.ActivarFuego();
            EntityManager.instance.player.GetDamage(damage);
        }
    }
}
