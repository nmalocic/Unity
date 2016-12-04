using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreTextScript : MonoBehaviour
{

    private Text _textComponent;

    private Text TextComponent
    {
        get
        {
            if (_textComponent == null)
            {
                _textComponent = GetComponent<Text>();
            }

            return _textComponent;
        }
    }

    public void SetScore(int score)
    {
        TextComponent.text = string.Format("SCORE: {0}", score);
    }

    private void Start()
    {
        TextComponent.text = "SCORE: 0";
    }
}
