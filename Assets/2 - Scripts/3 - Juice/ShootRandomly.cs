using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRandomly : MonoBehaviour
{
	[SerializeField] private float _shootInterval = 1f;

	[SerializeField, Range(1, 5)] private float _shootForce = 10f;


	private Rigidbody2D _rb;
	private float _timer;
	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
		Shoot();
	}

	private void Update()
	{
		_timer += Time.deltaTime;

		if (_timer >= _shootInterval)
		{
			Shoot();
			_timer = 0;
		}
	}

	private void Shoot()
	{
		Vector2 direction = Random.insideUnitCircle.normalized;
		transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
		_rb.AddForce(direction * _shootForce * 10, ForceMode2D.Impulse);
	}
}
