using UnityEngine;
using Assets.Scripts;

public class LaserControl : MonoBehaviour
{
    private float _moveSpeed = 0.05f;

	// Update is called once per frame
	void Update ()
    {
        MoveLaser();
	}

    private void MoveLaser()
    {
        Vector3 newPosotion = this.transform.position;
        newPosotion.y += _moveSpeed;
        this.transform.position = newPosotion;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag.IndexOf("Meteor") > -1)
        {
            int scoreToUpdate = 100;

            if(collider.tag.IndexOf("Big") > -1)
            {
                scoreToUpdate += 50;

                GameManager.instance.InstantiateBooster(collider.gameObject.transform.position);
            }

            GameManager.instance.UpdateScore(scoreToUpdate);
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
        }
    }
}
