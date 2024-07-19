using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	[Header("References")]
	[Space(10)]

	[SerializeField] private GameObject _brickPrefab;

	[Space(20)]

	[Header("Settings")]
	[Space(10)]

	[SerializeField] private float _countDownTimer = 60f;

	[Space(20)]

	[Header("Brick Settings")]
	[SerializeField] private int _brickCountMax = 4;
	[SerializeField] private int _brickCountMin = 1;

	private int bricksLeft;
	private float timeLeft;
	private int brickCount = 0;
	public float TimeLeft { get { return timeLeft; } }
	private void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
	}

	private void Start()
	{
		timeLeft = _countDownTimer;
		SpawnBricks(Random.Range(_brickCountMin, _brickCountMax));
	}

	private void Update()
	{
		timeLeft -= Time.deltaTime;

		if (timeLeft <= 0)
		{
			Score.SaveScore(brickCount);
			SceneManager.LoadScene("MainMenu");
		}
	}

	private void OnEnable()
	{
		InputHandler.Instance.PauseAction.performed += MainMenu;
	}

	private void OnDisable()
	{
		InputHandler.Instance.PauseAction.performed -= MainMenu;
	}

	private void SpawnBricks(int amount)
	{
		Vector3 rightEdge = GenerateColliderAroundCamera.GetRightEdge();
		Vector3 topEdge = GenerateColliderAroundCamera.GetTopEdge();

		for (int i = 0; i < amount; i++)
		{
			bricksLeft++;
			Instantiate(_brickPrefab, new Vector3(Random.Range(-rightEdge.x + 1, rightEdge.x - 1), Random.Range(-topEdge.y + 1, topEdge.y - 1), 0), Quaternion.identity);
		}
	}

	public void BrickDestroyed()
	{
		bricksLeft--;
		brickCount++;

		if (bricksLeft <= 0)
		{
			SpawnBricks(Random.Range(_brickCountMin, _brickCountMax));
		}
	}

	private void MainMenu(InputAction.CallbackContext context)
	{
		brickCount = 0;
		SceneManager.LoadScene("MainMenu");
	}
}
