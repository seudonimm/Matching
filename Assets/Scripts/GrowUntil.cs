using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;

public class GrowUntil : MonoBehaviour
{
    [SerializeField] Disc disc;
    [SerializeField] Rectangle rect;

    [SerializeField] float maxRadius, rate, t;

    // Start is called before the first frame update
    void Start()
    {
        t = 1;
    }

    // Update is called once per frame
    void Update()
    {
        rect.Height += Time.deltaTime * rate;
        rect.Width += Time.deltaTime * rate;

        rect.Color = new Color(rect.Color.r, rect.Color.g, rect.Color.b, Mathf.Lerp(0, 1, t));
        t -= Time.deltaTime;

        if (t <= 0)
        {
            Destroy(gameObject);
            //StartCoroutine(FadeAway());
        }
    }

    IEnumerator FadeAway()
    {
        rect.Color = new Color(rect.Color.r, rect.Color.g, rect.Color.b, Mathf.Lerp(0, 1, t));

        yield return new WaitForSeconds(t);

        Destroy(gameObject);

    }
}
