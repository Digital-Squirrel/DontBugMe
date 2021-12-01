using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject portalStart, portalEnd;
    // [SerializeField] private bool reverseDirection = false;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        //if (reverseDirection)
        //{
        //    transform.Translate(Vector3.right * speed * Time.deltaTime);
        //}
        //else
        //{
        //    transform.Translate(Vector3.left * speed * Time.deltaTime);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == portalEnd.gameObject.name)
        {
            transform.position = portalStart.transform.position;
        }
    }
}
