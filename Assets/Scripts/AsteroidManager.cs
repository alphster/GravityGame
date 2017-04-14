using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AsteroidManager : MonoBehaviour {

    public static AsteroidManager Instance { get; set; }

    public GameObject Prefab;
    public int Density = 20;
    public float MaxSpeed = 5f;
    public float MinSpeed = 1f;
    public float MinSpawnDistance = 5f;
    public float MaxSpawnDistance = 10f;

    List<GameObject> asteroids;
    
	// Use this for initialization
	void Start () {
        Instance = this;

        asteroids = new List<GameObject>();

        while (asteroids.Count < Density)
        {
            RandomlyInstantiateAsteroid(isStart: true);
        }
    }
	
	// Update is called once per frame
	void Update () {

        foreach(var asteroid in asteroids.ToList()) // TODO Making a ToList() list copy to fix error, not good
        {
            if (Vector2.Distance(this.transform.position, asteroid.transform.position) > MaxSpawnDistance)
            {
                RemoveAndDestroyAndRespawn(asteroid);
            }
        }
    }

    void RandomlyInstantiateAsteroid(bool isStart)
    {
        var asteroid = Instantiate(Prefab);

        if (isStart) // Might spawn near player
        {
            var x = Random.Range(-MaxSpawnDistance, MaxSpawnDistance);
            var y = Random.Range(-MaxSpawnDistance, MaxSpawnDistance);

            asteroid.gameObject.transform.position = new Vector2(x, y);
        }
        else // spawns further outside of player view
        {
            var x = Random.Range(MinSpawnDistance, MaxSpawnDistance);
            var xNeg = Random.Range(0, 2) == 1 ? 1f : -1f;
            var y = Random.Range(MinSpawnDistance, MaxSpawnDistance);
            var yNeg = Random.Range(0, 2) == 1 ? 1f : -1f;

            asteroid.gameObject.transform.position = new Vector2(transform.position.x + x * xNeg, transform.position.y + y * yNeg);
        }

        asteroids.Add(asteroid);
    }

    public void RemoveAndDestroyAndRespawn(GameObject obj)
    {
        asteroids.Remove(obj);
        Destroy(obj);
        RandomlyInstantiateAsteroid(isStart: false);
    }
}
