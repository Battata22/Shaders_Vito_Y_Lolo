using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTest : MonoBehaviour
{
    delegate void TestDelegate();

    TestDelegate test;


    private void Start()
    {
        test += a;
        test += c;
        test += b;

        test();
    }


    void a()
    {
        print("a");
    }

    void b()
    {
        print("b");
    }

    void c()
    {
        print("c");
    }
}
