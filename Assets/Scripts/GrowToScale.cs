using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowToScale : MonoBehaviour
{

    [SerializeField] float min, max, rate, t;
    [SerializeField] float x, y, z;

    // Start is called before the first frame update
    void Start()
    {
        t = 0;

    }

    // Update is called once per frame
    void Update()
    {
        x = Mathf.Lerp(min, max, t);
        y = Mathf.Lerp(min, max, t);
        z = Mathf.Lerp(min, max, t);

        gameObject.transform.localScale = new Vector3(x, y, z);
        t += Time.deltaTime * rate;


    }
}
