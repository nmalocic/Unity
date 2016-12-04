using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        [SerializeField]
        private ScoreTextScript _scoreText;

        [SerializeField]
        private GameObject booster;

        private int _currentScore = 0;

        private void Awake()
        {
            if (GameManager.instance != null)
            {
                Object.Destroy(this.gameObject);
            }

            GameManager.instance = this;
            Object.DontDestroyOnLoad(this);
        }

        private void Start()
        {
            _currentScore = 0;
        }

        public void UpdateScore(int score)
        {
            _currentScore += score;
            _scoreText.SetScore(_currentScore);
        }

        public void InstantiateBooster(Vector3 position)
        {
            if(Random.Range(1, 100) > 80)
            {
                Instantiate(booster, position, Quaternion.identity);
            }
        }
    }
}
