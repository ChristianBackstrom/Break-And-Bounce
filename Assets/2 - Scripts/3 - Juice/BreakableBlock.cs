using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
	private ParticleSystem particles;

	private void Awake()
	{
		particles = GetComponent<ParticleSystem>();
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		Play();
	}

	private void Play()
	{
		particles.Play();

		Destroy(this.GetComponent<SpriteRenderer>());
		Destroy(this.GetComponent<BoxCollider2D>());

		GameManager.Instance.BrickDestroyed();
	}

	private void OnParticleSystemStopped()
	{
		Destroy(gameObject);
	}
}
