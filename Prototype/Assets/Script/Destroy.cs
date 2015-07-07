using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    public float time = 0;

    IEnumerator Start ()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
