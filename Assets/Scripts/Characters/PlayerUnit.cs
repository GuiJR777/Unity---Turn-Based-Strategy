using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    // Private Variables
    private Vector3 _targetPosition;

    // Public Variables
    public float moveSpeed = 5f;

    // Constants
    private const float _minDistance = 0.1f;

    // MonoBehaviour Methods
    private void Update()
    {
        MoveToMousePosition();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(_targetPosition, transform.position) > _minDistance)
        {
            Move();
        }
    }

    // Main Methods
    private void Move()
    {
        Vector3 moveDirection = GetMoveDirection();
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    private Vector3 GetMoveDirection()
    {
        return (_targetPosition - transform.position).normalized;
    }

    private void ChangeTargetPosition(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
    }

    private void MoveToMousePosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = MouseWorld.GetMouseWorldPosition();
            ChangeTargetPosition(mousePosition);
        }
    }


}
