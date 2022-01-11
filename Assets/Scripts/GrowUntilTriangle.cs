using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
public class GrowUntilTriangle : MonoBehaviour
{
    [SerializeField] Triangle tri;

    [SerializeField] float maxRadius, rate, t;

    // Start is called before the first frame update
    void Start()
    {
        t = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * rate,
                                                transform.localScale.y + Time.deltaTime * rate,
                                                transform.localScale.z + Time.deltaTime * rate);

        tri.Color = new Color(tri.Color.r, tri.Color.g, tri.Color.b, Mathf.Lerp(0, 1, t));
        t -= Time.deltaTime;

        if (t <= 0)
        {
            Destroy(gameObject);
            //StartCoroutine(FadeAway());
        }
    }

    IEnumerator FadeAway()
    {
        tri.Color = new Color(tri.Color.r, tri.Color.g, tri.Color.b, Mathf.Lerp(0, 1, t));

        yield return new WaitForSeconds(t);

        Destroy(gameObject);

    }
}
