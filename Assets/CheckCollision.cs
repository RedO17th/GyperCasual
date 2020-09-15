using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    [SerializeField] private Manager headObject;
    private bool checkTrigger = true;
    //При соприкосновении отправлять сообщение
    void OnTriggerEnter()
    {
        if (checkTrigger)
        {
            headObject.SetNew();
            checkTrigger = false;
        }
        StartCoroutine(WaitCheck());
    }
    //Установка главного объекта триггер проверки прохода шарика.
    public void Set(Manager manager)
    {
        headObject = manager;
    }
    IEnumerator WaitCheck()
    {
        yield return new WaitForSeconds(0.5f);
        checkTrigger = true;
    }
}
