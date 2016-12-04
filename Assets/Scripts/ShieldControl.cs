using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class ShieldControl : MonoBehaviour 
{
	[SerializeField]
	private float showHideTime = 1f;
	private SpriteRenderer spriteRenderer;
	private float passedTime = 0.0f;

	void Start()
	{
		this.spriteRenderer = this.GetComponent<SpriteRenderer> ();
	}

    public void ShowShield()
    {
        this.StopAllCoroutines();
        this.StartCoroutine(ImageShowing());
    }

    public void HideShield()
    {
        this.StopAllCoroutines();
        this.StartCoroutine(ImageHiding());
    }

    private IEnumerator ImageHiding()
	{
		while(this.passedTime < this.showHideTime) 
		{
			this.passedTime += Time.deltaTime;
			float percentDone = this.passedTime / this.showHideTime;
			this.SetImageAlpha (1 - percentDone);
			yield return true;
		}

		this.passedTime = 0.0f;
	}

	private IEnumerator ImageShowing()
	{
		while(this.passedTime < this.showHideTime) 
		{
			this.passedTime += Time.deltaTime;
			float percentDone = this.passedTime / this.showHideTime;
			this.SetImageAlpha (percentDone);
			yield return true;
		}

		this.passedTime = 0.0f;
	}



	private void SetImageAlpha(float newAlpha)
	{
		Color newColor = this.spriteRenderer.color;
		newColor.a = newAlpha;
		this.spriteRenderer.color = newColor;
	}
}
