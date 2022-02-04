using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    private Camera _camera;
    private NavMeshAgent _agent;
    public Joystick joystick;
    public bool Active;

    private void Start()
    {
        _camera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {           
            if (Active)
            {
                RaycastHit hit;
                if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    _agent.SetDestination(hit.point);
                   
                }
            }
             
        }        
        if (joystick.Horizontal != 0)
        {
            Active = false;
            _agent.velocity = new Vector3(joystick.Horizontal, 0)* _agent.speed;
            _agent.ResetPath();
        }
        else Active = true;
    }
}
