using UnityEngine;

public class slime_spawnerlv2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject slimeprefab;
    public float interval = 10f;
    public int max_slimes = 10;

    public int count = 0;
    //public Vector3 offset;
    void Start()
    {
        Slime_Pattern1();
    }
    
    // Update is called once per frame
    void Slime_Pattern1()
    {

        InvokeRepeating("SpawnSlime", 0, interval);

        Invoke("Slime_Pattern", interval * 2);
        
    }
    void Slime_Pattern2()
    {
        CancelInvoke("SpawnSlime");
        InvokeRepeating("SpawnSlime", 0, interval);
        InvokeRepeating("SpawnSlime", 1f, interval + 1f);
        Invoke("Slime_Pattern3", interval * 2+2f);
        
    }
    void Slime_Pattern3()
    {
        CancelInvoke("SpawnSlime");
        InvokeRepeating("SpawnSlime", 0, interval);
        InvokeRepeating("SpawnSlime", 1f, interval+1f);
        InvokeRepeating("SpawnSlime", 1f, interval+2f);
        
        
    }
    void SpawnSlime()
    {
        if (count >= max_slimes)
        {
            CancelInvoke();
            return;
        }
            
        //spawn.position = new Vector3(spawn.position.x, 0, 0) - offset;
        GameObject spawnedSlime = Instantiate(slimeprefab);
        spawnedSlime.transform.SetParent(transform);//,spawn.position,Quaternion.identity);
        count++;
    }

}
