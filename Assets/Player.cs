using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Vector3 offsetCam;
    private Rigidbody rb;

    private Transform floor = null;
    private Quaternion angle;
    private Quaternion cachAngle;

    private float angleHor;
    private float angleVert;
    //private float mouseSens = 0.5f;
    //Android
    private Touch touch;
    private Vector2 touchPosition;
    private Quaternion rotationY;
    private Quaternion rotationX;
    private float mouseSens = 0.05f;

    private float waitGame = 1f;
    private bool go = false;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        StartCoroutine(Wait());
    }
    void Update()
    {
        rb.WakeUp();   
    }
    void FixedUpdate()
    {
        cam.transform.position = transform.position + offsetCam;
        cam.transform.LookAt(transform);

        if (go)
        {
            //angleHor += Input.GetAxis("Mouse X") * mouseSens;
            //angleVert += Input.GetAxis("Mouse Y") * mouseSens;

            ////angleHor = Mathf.Clamp(angleHor, -90f, -98f);
            ////angleVert = Mathf.Clamp(angleVert, -83f, -97f);
            ////angleHor = Clamp(angleHor, -90f, -98f);
            ////angleVert = Clamp(angleVert, -83f, -97f);

            //Quaternion rotationX = Quaternion.AngleAxis(angleHor, Vector3.up);
            //Quaternion rotationY = Quaternion.AngleAxis(angleVert, Vector3.right);

            //if (floor)
            //    floor.localRotation = angle * rotationX * rotationY;

            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    rotationX = Quaternion.Euler(0f, touch.deltaPosition.x * mouseSens, 0f);
                    rotationY = Quaternion.Euler(touch.deltaPosition.y * mouseSens, 0f, 0f);
                    //Quaternion rotationX = Quaternion.AngleAxis(touch.deltaPosition.x * mouseSens, Vector3.up);
                    //Quaternion rotationY = Quaternion.AngleAxis(touch.deltaPosition.y * mouseSens, Vector3.right);
                    if (floor)
                        floor.localRotation *= rotationX * rotationY;//angle * rotationX * rotationY;
                }
            }

        }

    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.CompareTag("Floor"))
        {
            if (floor != null)
                floor.GetComponent<Floors>().SetRotation(cachAngle);
            floor = coll.transform;
            angle = floor.localRotation;
            cachAngle = angle;
        }
    }
    private float Clamp(float angle, float min, float max)
    {
        if (angle <= min)
            return min;
        else
            if (angle >= max)
            return max;
        else
            return angle;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitGame);
        go = true;
    }
}
