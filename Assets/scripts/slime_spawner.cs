using UnityEngine;

public class slime_spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject slimeprefab;
    public float interval = 10f;
    public int max_slimes = 10;

    private int count = 0;
    public Vector3 offset;
    void Start()
    {
        InvokeRepeating("SpawnSlime", 0, interval);
    }

    // Update is called once per frame
    void SpawnSlime()
    {
        if (count >= max_slimes) return;
        //spawn.position = new Vector3(spawn.position.x, 0, 0) - offset;
        GameObject spawnedSlime = Instantiate(slimeprefab);
        spawnedSlime.transform.SetParent(transform);//,spawn.position,Quaternion.identity);
        count++;
    }

}
