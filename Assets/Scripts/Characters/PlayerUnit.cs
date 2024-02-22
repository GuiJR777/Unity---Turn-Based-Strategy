using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    // Serializable Fields
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotateSpeed = 10f;
    [SerializeField] private GameObject _selectionCircle;

    // Private Variables
    private Vector3 _targetPosition;

    // Constants
    private const float _minDistance = 0.1f;

    // MonoBehaviour Methods
    private void Awake()
    {
        _targetPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(_targetPosition, transform.position) > _minDistance)
        {
            Move();
            return;
        }

        _animator.SetBool("IsWalking", false);
    }

    // Main Methods
    private void Move()
    {
        _animator.SetBool("IsWalking", true);
        Vector3 moveDirection = GetMoveDirection();
        transform.position += moveDirection * _moveSpeed * Time.fixedDeltaTime;
        LerpRotation();
    }

    private Vector3 GetMoveDirection()
    {
        return (_targetPosition - transform.position).normalized;
    }

    private void LerpRotation()
    {
        Vector3 moveDirection = GetMoveDirection();
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

        targetRotation.x = 0;
        targetRotation.z = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.fixedDeltaTime * _rotateSpeed);
    }

    public void ChangeTargetPosition(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
    }

    public void SetSelected(bool isSelected)
    {
        _selectionCircle.SetActive(isSelected);
    }

}
