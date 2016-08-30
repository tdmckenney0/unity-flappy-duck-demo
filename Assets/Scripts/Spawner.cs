using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public ObstacleMove[] prefabs;
    public int poolSize;
    public float spawnXPos;

    public float spawnInterval;
    private float timer;

    private LinkedList<ObstacleMove> pool;

    // Use this for initialization
    void Start()
    {

        pool = new LinkedList<ObstacleMove>();

        for (int i = 0; i < poolSize; i++)
        {
            int rNum = Random.Range(0, prefabs.Length);
            ObstacleMove clone = Instantiate<ObstacleMove>(prefabs[rNum]);

            clone.gameObject.SetActive(false);
            clone.transform.SetParent(this.transform);
            pool.AddLast(clone);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if(timer >= spawnInterval)
        {
            Spawn();
            timer -= spawnInterval;
        }
	}

    void Spawn()
    {
        if(pool.Count == 0)
        {
            Debug.Log("Nothing left to spawn");
            return;
        }

        ObstacleMove next = pool.First.Value;

        next.transform.position = new Vector3(spawnXPos, next.homePoint.y);
        next.gameObject.SetActive(true);

        pool.RemoveFirst();
    }

    void Recycle(GameObject garbage)
    {
        ObstacleMove mover = garbage.GetComponent<ObstacleMove>();

        if (mover == null)
        {
            Debug.Log("Could not add " + garbage.name);
            return;
        }

        garbage.SetActive(false);
        pool.AddLast(mover);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            Recycle(other.gameObject);
        }
    }
}
