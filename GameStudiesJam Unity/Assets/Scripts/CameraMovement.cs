using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 m_Position = Vector3.up;
    [SerializeField] private float m_Speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.position += m_Speed*m_Position*Time.deltaTime;
    }
}
