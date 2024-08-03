using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{

    public GameObject pipePrefab;// tham chieu toi prelab cau pipe
    public float spawnRate;//tan xuat spawn
    public float heightOffset;//bien do cao



    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer > spawnRate)
        {
            spawnPipe();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    void spawnPipe()
    {
        float lowestpoit = transform.position.y - heightOffset;
        float hightestpoint = transform.position.y + heightOffset;

        GameObject newPipe = Instantiate(pipePrefab, new Vector3(pipePrefab.transform.position.x,Random.Range(lowestpoit,hightestpoint),0),transform.rotation);
        Destroy(newPipe,10f);
    }
}
