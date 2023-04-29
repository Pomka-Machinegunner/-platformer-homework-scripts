using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGraf : MonoBehaviour
{
    [SerializeField] AnimationCurve _curve;

    private void Update()
    {
        _curve.AddKey(Time.time, transform.eulerAngles.z);
    }
}
