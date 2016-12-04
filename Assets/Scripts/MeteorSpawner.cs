using UnityEngine;
using System.Collections;

public class MeteorSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] _meteorPrefabs;
	private float _meteorSpawnTimePassed = 0;
    private float _boosterSpawnTimePassed = 0;
    private float _topYValue = 0;

    
		
    void Start()
    {
        _topYValue = Camera.main.ViewportToWorldPoint(Vector2.one).y;
    }

	// Update is called once per frame
	void Update ()
    {
        _boosterSpawnTimePassed += Time.deltaTime;
        _meteorSpawnTimePassed += Time.deltaTime;
        if (_meteorSpawnTimePassed > 1.5f)
        {
            SpawnMeteor();
        }
    }

    private void SpawnMeteor()
    {
        _meteorSpawnTimePassed = 0.0f;
        GameObject pickedObject = this._meteorPrefabs[Random.Range(0, this._meteorPrefabs.Length)];
        float topXValue = GetTopXValue();
        Vector3 spawnPoint = new Vector3(topXValue, _topYValue, 0);
        Instantiate(pickedObject, spawnPoint, Quaternion.identity);
    }

    private static float GetTopXValue()
    {
        return Random.Range(Camera.main.ViewportToWorldPoint(Vector2.zero).x, Camera.main.ViewportToWorldPoint(Vector2.one).x);
    }
}
