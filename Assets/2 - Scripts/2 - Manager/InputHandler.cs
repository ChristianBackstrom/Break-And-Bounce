using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
	public static InputHandler Instance { get; private set; }

	private PlayerInput _playerInput;

	private InputAction _dragAction;
	private InputAction _cancelAction;
	private InputAction _resetAction;
	private InputAction _pauseAction;


	public InputAction DragAction { get => _dragAction; }
	public InputAction CancelAction { get => _cancelAction; }
	public InputAction ResetAction { get => _resetAction; }
	public InputAction PauseAction { get => _pauseAction; }


	private void Awake()
	{
		#region Singleton
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);

		print("InputHandler created");
		#endregion

		_playerInput = GetComponent<PlayerInput>();
	}

	#region Inputs
	private void OnEnable()
	{
		_dragAction = _playerInput.actions["Drag"];
		_dragAction.Enable();

		_cancelAction = _playerInput.actions["Cancel"];
		_cancelAction.Enable();

		_resetAction = _playerInput.actions["Reset"];
		_resetAction.Enable();

		_pauseAction = _playerInput.actions["Pause"];
		_pauseAction.Enable();
	}
	#endregion
}
