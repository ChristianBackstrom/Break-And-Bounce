using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerState : MonoBehaviour
{
	public static PlayerState Instance;
	[Header("References")]
	[SerializeField] private DragLine _dragLine;
	[SerializeField] private DragAndShoot _dragAndShoot;

	[SerializeField] public State state = State.Idle;

	[HideInInspector] public Vector2 dragStartPos;

	private void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
	}

	private void OnEnable()
	{
		InputHandler.Instance.DragAction.performed += Drag;
		InputHandler.Instance.DragAction.canceled += Shoot;
		InputHandler.Instance.CancelAction.performed += CancelDrag;
		InputHandler.Instance.ResetAction.performed += ResetPosition;
	}

	private void OnDisable()
	{
		InputHandler.Instance.DragAction.performed -= Drag;
		InputHandler.Instance.DragAction.canceled -= Shoot;
		InputHandler.Instance.CancelAction.performed -= CancelDrag;
		InputHandler.Instance.ResetAction.performed -= ResetPosition;
	}

	private void Drag(InputAction.CallbackContext context)
	{
		if (state == State.Idle)
		{
			state = State.Dragging;
			StartDragging(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
		}
	}

	private void Shoot(InputAction.CallbackContext context)
	{
		if (state == State.Dragging)
		{
			state = State.Idle;
			_dragAndShoot.Shoot(dragStartPos, Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
		}
	}

	private void CancelDrag(InputAction.CallbackContext context)
	{
		if (state == State.Dragging)
		{
			state = State.Idle;
			dragStartPos = Vector2.zero;
		}
	}

	private void ResetPosition(InputAction.CallbackContext context)
	{
		if (state == State.Idle)
		{
			_dragAndShoot.ResetPosition();
		}
	}


	private void StartDragging(Vector2 dragStartPos)
	{
		state = State.Dragging;
		this.dragStartPos = dragStartPos;
	}
}

public enum State
{
	Idle,
	Dragging
}