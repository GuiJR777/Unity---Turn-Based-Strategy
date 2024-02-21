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
        MoveToTestPosition();
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



    // To Test TODO: Remove
    private void MoveToTestPosition()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 newPosition = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)) + transform.position;

            ChangeTargetPosition(newPosition);
        }
    }

}
