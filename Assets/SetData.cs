using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetData : MonoBehaviour
{
    [SerializeField] private CheckCollision trigger;
    public void SetObject(Manager manager)
    {
        trigger.Set(manager);
    }
}
