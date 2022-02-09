using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    private Camera _camera;
    private NavMeshAgent _agent;    
    private bool _active;

    private void Start()
    {
        _camera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {           
            if (_active)
            {
                RaycastHit hit;
                if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    _agent.SetDestination(hit.point);
                   
                }
            }
             
        }        
        if (_joystick.Horizontal != 0)
        {
            _active = false;
            _agent.velocity = new Vector3(_joystick.Horizontal, 0,_joystick.Vertical)* _agent.speed;
            _agent.ResetPath();
        }
        else _active = true;
    }
}
