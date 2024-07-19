using System.Collections;
using System;
using UnityEngine;
using TMPro;
public class countdownTimer : MonoBehaviour
{
	private TMP_Text _text;

	private void Awake()
	{
		_text = GetComponent<TMP_Text>();
	}


	private void Update()
	{
		float time = GameManager.Instance.TimeLeft;

		TimeSpan timeSpan = TimeSpan.FromSeconds(time);
		_text.text = timeSpan.ToString(@"mm\:ss");
	}
}
