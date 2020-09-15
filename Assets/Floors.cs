using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floors : MonoBehaviour
{
    public void SetRotation(Quaternion angle)
    {
        transform.localRotation = angle;
    }
}
