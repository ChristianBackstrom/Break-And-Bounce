using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
	private TMP_Text _text;
	private int _counter = 0;

	private void Awake()
	{
		_text = GetComponent<TMP_Text>();
		Object.FindObjectOfType<OnCollision>().OnHitEvent += Increment;
	}

	public void Increment()
	{
		_text.text = _counter++.ToString();
	}
}
