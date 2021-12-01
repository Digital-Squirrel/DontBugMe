using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 900;
    [SerializeField] private float maxSpeed = 200f;
    [SerializeField] private Slider irritationSlider;

    private new Rigidbody rigidbody;
    private bool isHideControlsCalled = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        if(Input.anyKey && !isHideControlsCalled)
        {
            UIEvents.current.HideControls();
            isHideControlsCalled = true;
        }

        Vector3 force = new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime * -1;
        rigidbody.AddForce(force);

        RotatePlayer(force);

        if (rigidbody.velocity.magnitude > maxSpeed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            UIEvents.current.IncreaseIrritationLevel();

            if(irritationSlider != null)
            {
                if(irritationSlider.value == irritationSlider.maxValue)
                {
                    this.gameObject.SetActive(false);
                    //TODO: Create explosion here.
                    UIEvents.current.TriggerIrritated();
                }
            }
        }

        if (collision.transform.tag == "Car")
        {
            DisablePlayer();
            UIEvents.current.KillPlayer();
        }

        if (collision.transform.tag == "Pit")
        {
            DisablePlayer();
            UIEvents.current.FallOffWorld();
        }

        if (collision.transform.tag == "Finish")
        {
            DisablePlayer();
            UIEvents.current.TriggerSuccess();
        }
    }

    private void DisablePlayer()
    {
        this.gameObject.SetActive(false);
    }

    // Angular speed in radians per sec.
    [SerializeField] private float rotateSpeed = 5.0f;
    private void RotatePlayer(Vector3 force)
    {
        float singleStep = rotateSpeed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, force, singleStep, 0.0f);

        Debug.DrawRay(transform.position, newDirection, Color.red);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
