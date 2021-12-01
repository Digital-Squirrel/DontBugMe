using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float distanceFromPlayer = 5f;
    [SerializeField] private float textDisplayDistance = 6f;
    [SerializeField] GameObject speechBubble = null;

    private Rigidbody rigidbody;
    private Vector3 startPosition = Vector3.zero;
    private TextMesh textMesh;

    private string[] questions = new string[]
    {
        "Excuse me. Do you have the time?",
        "Would you like to hear about Jesus?",
        "Don't I know you from somewhere?",
        "Here take a flyer.",
        "Do you think I look fat in this?",
        "Do you know the way to 4th and main?",
        "Can I have a dollar?",
        "Hey have I got a deal for you.",
        "Would you be interested in buying time share?",
        "Back in my day...",
        "Hey buddy, hey, hey, let me talk to you for a sec.",
        "My grandson would love to mee you.",
    };



    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        startPosition = transform.position;

        textMesh = speechBubble.GetComponent<TextMesh>();
        textMesh.text = questions[Random.Range(0, questions.Length - 1)];
    }

    void FixedUpdate()
    {
        speechBubble.SetActive(false);

        if (target == null)
        {
            Debug.Log("Target for " + this.name + " is missting");
            return;
        }

        float step = speed * Time.deltaTime;
        var distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget < distanceFromPlayer && target.gameObject.activeSelf == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        else
        {            
            transform.position = Vector3.MoveTowards(transform.position, startPosition, step);
        }

        if (!speechBubble.activeSelf && distanceToTarget < textDisplayDistance)
        {            
            speechBubble.SetActive(true);

            if (target.gameObject.activeSelf != true) speechBubble.SetActive(false);
        }



        if (distanceToTarget < 0.001f)
        {
            target.position *= -1.0f;
        }


    }
}
