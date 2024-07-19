using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squish : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private Rigidbody2D _playerRigidBody;
	private TrailRenderer _trailRenderer;

	[Space(20)]

	[Header("Settings")]
	[SerializeField] private AnimationCurve _squishCurveX;
	[SerializeField] private AnimationCurve _squishCurveY;

	private float _maxVelocity = 60f;

	private void Awake()
	{
		_trailRenderer = GetComponent<TrailRenderer>();
	}

	private void Update()
	{
		transform.localScale = SquishScale();
	}

	private Vector2 SquishScale()
	{
		Vector2 scale = Vector2.one;

		float speed = _playerRigidBody.velocity.magnitude;

		scale.x = 1 + _squishCurveX.Evaluate(speed / _maxVelocity);
		scale.y = 1 - _squishCurveY.Evaluate(speed / _maxVelocity);
		_trailRenderer.widthMultiplier = scale.y;

		return scale;
	}
}
