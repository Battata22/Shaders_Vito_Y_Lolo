using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StructBolas
{
    public KeyCode ActivationKey;
    public BaseBall Bola;

    public void Set(BaseBall bola)
    {
        Bola = bola;
    }
}
