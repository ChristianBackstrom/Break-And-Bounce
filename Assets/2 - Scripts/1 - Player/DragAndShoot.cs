using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndShoot : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private Transform _playerObject;


	[Space(20)]

	[Header("Settings")]
	[Space(10)]
	[SerializeField] private float _minDragDistance = .1f;
	[SerializeField] private float _maxDragDistance = 2f;
	[SerializeField] private float _force = 1f;
	[SerializeField] private LayerMask _layerMask;


	private PlayerState _playerState;

	private Rigidbody2D _rb;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
		_playerState = PlayerState.Instance;
	}

	private void Update()
	{
		RotationBasedOnVelocity();

		DragBasedOnVelocity();

	}

	public void Shoot(Vector2 dragStartPos, Vector2 dragEndPos)
	{
		_rb.drag = 0;

		Vector2 dragDirection = dragEndPos - dragStartPos;

		float dragDistance = dragDirection.magnitude;

		if (dragDistance > _minDragDistance)
		{
			dragDirection.Normalize();

			dragDistance = Mathf.Clamp(dragDistance, _minDragDistance, _maxDragDistance);

			transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dragDirection.y, dragDirection.x) * Mathf.Rad2Deg);

			_rb.velocity = _rb.velocity.normalized;

			_rb.AddForce(-transform.right * dragDistance * _force, ForceMode2D.Impulse);
		}
	}

	public void ResetPosition()
	{
		_rb.velocity = Vector2.zero;
		_rb.angularVelocity = 0;
		_rb.drag = 0;

		transform.position = Vector2.zero;
		transform.rotation = Quaternion.identity;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		_rb.drag += .2f;
	}

	private void DragBasedOnVelocity()
	{
		if (_rb.velocity.magnitude < .2f)
			_rb.drag = 0;
	}


	private void RotationBasedOnVelocity()
	{
		Vector2 velocity = -_rb.velocity;

		Quaternion targetRotation = Quaternion.Euler(0, 0, Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg);

		transform.rotation = targetRotation;
	}
}
