using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWater : EnemyBase
{
    protected override void Start()
    {
       base.Start();
        type = EnemyType.Water;
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
}
