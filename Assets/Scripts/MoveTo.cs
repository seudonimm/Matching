using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public Vector2 initialPos, destination, currPos;
    [SerializeField] bool whereItStarts, worldTrans;
    [SerializeField] float x, y, t;

    // Start is called before the first frame update
    void Start()
    {
        if (whereItStarts)
        {
            initialPos = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        x = Mathf.Lerp(initialPos.x, destination.x, t);
        y = Mathf.Lerp(initialPos.y, destination.y, t);
        t += Time.deltaTime;

        currPos = new Vector2(x, y);

        if (worldTrans)
        {
            transform.position = currPos;

        }
        else
        {
            transform.localPosition = currPos;
        }
    }
}
