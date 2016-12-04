using UnityEngine;

public class ShipControl : MonoBehaviour {

	[SerializeField]
	private float moveSpeed = 1f;
    [SerializeField]
    private LaserControl _laser;

	private Vector2 lowerLeft;
	private Vector2 upperRight;
    private ShieldControl _showHideScript;
    private bool _isShieldActive = false;

	void Start()
	{
		this.lowerLeft = Camera.main.ViewportToWorldPoint (Vector2.zero);
		this.upperRight = Camera.main.ViewportToWorldPoint (Vector2.one);
        _showHideScript = gameObject.GetComponentInChildren<ShieldControl>();
	}

	public void MoveShip(float x, float y)
	{
		Vector3 newPosition = this.transform.position;
		newPosition.x += x * moveSpeed;
		newPosition.y += y * moveSpeed;
		this.transform.position = newPosition;
		ClampShipToScreen ();
	}

	void Update()
	{
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		this.MoveShip (x, y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_laser, this.transform.position, Quaternion.identity);
        }
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
        
		if (collider.tag == "Meteor") 
		{
            if (_isShieldActive)
            {                
                _showHideScript.HideShield();
                _isShieldActive = false;
                
            }
            else
            {
                Application.Quit();
            }

            Destroy(collider.gameObject);
        }

        if(collider.tag == "Booster")
        {
            if (!_isShieldActive)
            {
                _showHideScript.ShowShield();
                _isShieldActive = true;
            }

            Destroy(collider.gameObject);
        }
	}

	void ClampShipToScreen()
	{
		Vector3 shipPostion = this.transform.position;
		shipPostion.x = Mathf.Clamp (shipPostion.x, lowerLeft.x, upperRight.x);
		shipPostion.y = Mathf.Clamp (shipPostion.y, lowerLeft.y, upperRight.y);

		this.transform.position = shipPostion;
	}
}