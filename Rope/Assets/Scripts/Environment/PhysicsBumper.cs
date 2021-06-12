using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PhysicsBumper : MonoBehaviour
{
	[SerializeField]
	private float force;
	[SerializeField]
	private ForceMode2D forceMode = ForceMode2D.Impulse;

	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.LogFormat("Collision with {0}", other.collider.gameObject.name);
		var averageNormal = -(other.contacts.Select(contact => contact.normal).Aggregate((a, b) => a + b) / other.contactCount).normalized;
		other.rigidbody?.AddForce(averageNormal * this.force, this.forceMode);
	}
}
