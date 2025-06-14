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

    protected override void OnDestroy()
    {
        meMuero += ParticulasMuerte;
        meMuero += AudioMuerte;
        base.OnDestroy();
        meMuero -= ParticulasMuerte;
        meMuero -= AudioMuerte;
    }
}
