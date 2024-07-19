using UnityEngine;
using UnityEngine.InputSystem;


public class DragLine : MonoBehaviour
{

	[Header("Line Renderer")]
	[SerializeField] private LineRenderer _lineRenderer;
	[Space(10)]
	[SerializeField] private AnimationCurve _lineWidthCurve;
	[SerializeField] private int _lineResolution = 10;


	private PlayerState _playerState;
	private void Awake()
	{
		_playerState = PlayerState.Instance;
	}

	private void Start()
	{
		_playerState = PlayerState.Instance;
	}

	private void Update()
	{
		RenderLine();
	}

	private void RenderLine()
	{
		if (_playerState.state == State.Dragging)
		{

			_lineRenderer.enabled = true;
			_lineRenderer.SetPosition(0, _playerState.dragStartPos);

			Vector2 mouseToScreen = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

			for (int i = 0; i < _lineResolution; i++)
			{
				Vector2 pos = Vector2.Lerp(_playerState.dragStartPos, mouseToScreen, i / (float)_lineResolution);
				_lineRenderer.SetPosition(i, pos);
			}
		}
		else
		{
			_lineRenderer.enabled = false;
		}
	}

	private void OnValidate()
	{
		_lineRenderer.positionCount = (int)_lineResolution;
		_lineRenderer.widthCurve = _lineWidthCurve;
	}
}
