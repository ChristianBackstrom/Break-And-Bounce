using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateColliderAroundCamera : MonoBehaviour
{
	[SerializeField] private GameObject _colliderObject;

	private Vector3 _rightEdge;
	private Vector3 _topEdge;

	private Camera _camera;

	private GameObject _rightCollider;
	private GameObject _leftCollider;

	private GameObject _topCollider;
	private GameObject _bottomCollider;

	private void Awake()
	{
		_camera = Camera.main;
	}

	// Generate a collider around the camera to make player always visible
	#region GenerateCollider
	private void Start()
	{
		GetEdges();



		_leftCollider = Instantiate(_colliderObject, new Vector3(-_rightEdge.x - .5f, 0, 0), Quaternion.identity, transform);

		_leftCollider.transform.localScale = new Vector3(1, 100, 1);



		_rightCollider = Instantiate(_colliderObject, new Vector3(_rightEdge.x + .5f, 0, 0), Quaternion.identity, transform);

		_rightCollider.transform.localScale = new Vector3(1, 100, 1);



		_topCollider = Instantiate(_colliderObject, new Vector3(0, _topEdge.y + .5f, 0), Quaternion.identity, transform);

		_topCollider.transform.localScale = new Vector3(100, 1, 1);



		_bottomCollider = Instantiate(_colliderObject, new Vector3(0, -_topEdge.y - .5f, 0), Quaternion.identity, transform);

		_bottomCollider.transform.localScale = new Vector3(100, 1, 1);
	}
	#endregion

	private Vector3 _rightEdgeBefore;
	private Vector3 _topEdgeBefore;
	private void Update()
	{
		GetEdges();

		if (_rightEdgeBefore != _rightEdge || _topEdgeBefore != _topEdge)
		{
			UpdatePositions();
		}

		_rightEdgeBefore = _rightEdge;
		_topEdgeBefore = _topEdge;
	}

	private void GetEdges()
	{
		// Get the position of the right edge of the camera
		_rightEdge = GetRightEdge();

		// Get the position of the top edge of the camera
		_topEdge = GetTopEdge();
	}

	public static Vector3 GetRightEdge()
	{
		return Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
	}

	public static Vector3 GetTopEdge()
	{
		return Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
	}

	private void UpdatePositions()
	{
		_leftCollider.transform.position = new Vector3(-_rightEdge.x - .5f, 0, 0);
		_rightCollider.transform.position = new Vector3(_rightEdge.x + .5f, 0, 0);
		_topCollider.transform.position = new Vector3(0, _topEdge.y + .5f, 0);
		_bottomCollider.transform.position = new Vector3(0, -_topEdge.y - .5f, 0);
	}

}
