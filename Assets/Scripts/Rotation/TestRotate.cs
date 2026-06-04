using System;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class TestRotate : MonoBehaviour
{
    public Transform from;
    public Transform to;
    public float speed = 0.01f;
    public float timeCount = 0.0f;

    void Update()
    {
        transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, timeCount * speed); Debug.Log("QuaternionFires");
        timeCount = timeCount + Time.deltaTime;
    }

}