using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public Transform player;

    public float intervalX = 20.0f;
    public float intervalY = 20.0f;

    public List<Transform> planes = new List<Transform>();
    Vector2 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            planes.Add(this.transform.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerInterval = new Vector2(Mathf.Floor(player.position.x / intervalX), Mathf.Floor(player.position.z / intervalY));
        if(playerInterval != currentPos)
        {
            currentPos = playerInterval;
            UpdateMap();
        }
    }

    void UpdateMap()
    {
        int i = 0;
        for (int x = -1; x <= 1; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                Vector3 pos = new Vector3((currentPos.x + x) * intervalX, 0, (currentPos.y + z) * intervalY);
                planes[i].position = pos;
                i++;
            }
        }
    }
}
