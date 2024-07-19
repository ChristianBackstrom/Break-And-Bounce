using UnityEngine;


public class OnCollision : MonoBehaviour
{
	[Header("References")]
	[Space(10)]

	[SerializeField] private ParticleSystem _particleSystem;


	[Space(20)]


	[Header("Settings")]
	[Space(10)]

	[SerializeField] private float _cameraShakeDuration = .1f;
	[SerializeField] private float _cameraShakeMagnitude = .1f;
	[SerializeField] private LayerMask _counterIncreaseLayerMask;

	public delegate void OnHit();
	public event OnHit OnHitEvent;

	private void OnCollisionEnter2D(Collision2D other)
	{
		_particleSystem.Play();

		StartCoroutine(CameraShake.Shake(_cameraShakeDuration, _cameraShakeMagnitude));

		if (AudioManager.Instance != null)
			AudioManager.Instance.Play("Bounce");


		// checks if the layer of the object that collided with this object is in the layermask
		if (_counterIncreaseLayerMask != (_counterIncreaseLayerMask | (1 << other.gameObject.layer)))
			return;

		OnHitEvent?.Invoke();
		AudioManager.Instance.Play("BlockBreak");
	}
}
