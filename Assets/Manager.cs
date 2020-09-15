using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject prefabPlatform;
    private GameObject platform;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 offsetPos;

    void Awake()
    {
        platform = Instantiate(prefabPlatform, startPos, Quaternion.identity, transform);
        //
        platform.transform.GetComponent<SetData>().SetObject(this);
    }
    public void SetNew()
    {
        platform.transform.position += offsetPos;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}
