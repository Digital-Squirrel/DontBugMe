using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{
    [SerializeField] private Transform target;

    // Angular speed in radians per sec.
    private float speed = 5.0f;
    private Transform startPosition;

    private Vector3 levelTargetPos = new Vector3(0,0,0);
    private void Start()
    {
        startPosition = transform;        
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= 10f)
        {
            var lookPos = target.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
            // transform.LookAt(levelTargetPos);
        }
        else
        {
            transform.LookAt(startPosition);
        }
    }
}
