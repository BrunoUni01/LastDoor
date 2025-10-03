using UnityEngine;
using System.Collections;

public class CamaraController : MonoBehaviour
{
    public float moveSpeed = 10f;

    public void MoverACuarto(Vector3 puntoFocus, bool instant = false)
    {
        Vector3 target = new Vector3(puntoFocus.x, puntoFocus.y, transform.position.z);
        StopAllCoroutines();

        if (instant)
        {
            transform.position = target;
        }
        else
        {
            StartCoroutine(MoverRutina(target));
        }
    }
    private IEnumerator MoverRutina(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = target;
    }
}

