using UnityEngine;

public class MeteorKiller : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Meteor") 
		{
			Destroy(collider.gameObject);
		}
	}
}
