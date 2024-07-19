using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecenterTutorial : MonoBehaviour
{
	[Header("References")]
	[Space(10)]

	[SerializeField] private GameObject _recenterTutorial;


	private GameObject _player;

	[SerializeField] private bool _isPlayerOutside;
	private bool _lastCheck;

	private Animator _animator;

	private void Awake()
	{
		_player = GameObject.FindGameObjectWithTag("Player");
		_animator = _recenterTutorial.GetComponent<Animator>();
	}

	private void Update()
	{
		_lastCheck = _isPlayerOutside;
		_isPlayerOutside = OutsideOfCamera.IsOutside(_player.transform.position);

		if (_isPlayerOutside != _lastCheck)
		{
			AnimateTextEntry(_isPlayerOutside);
		}


		_animator.SetBool("IsPlayerOutside", _isPlayerOutside);
	}

	private void AnimateTextEntry(bool isEntering)
	{
		if (isEntering)
		{
			print("Entering");
			_animator.SetTrigger("Entry");
		}
		else
		{
			_animator.SetTrigger("Exit");
		}
	}
}


