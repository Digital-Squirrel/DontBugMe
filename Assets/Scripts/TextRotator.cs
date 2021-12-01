using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRotator : MonoBehaviour
{
    private Camera m_Camera;

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Camera == null)
            transform.LookAt(m_Camera.transform);
    }
}
