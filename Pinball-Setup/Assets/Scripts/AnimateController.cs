using UnityEngine;
using System.Collections;

public class AnimateController : MonoBehaviour
{
    public Sprite[] spriteSet;
    public float fps;
    // #1
    public GameObject treeObject;
    private float turnSpeed = 30f;

    // #2
    private void FixedUpdate()
    {
        if(treeObject != null)
        {
            treeObject.transform.Rotate(new Vector3(0, 0, turnSpeed * Time.deltaTime));
        }
    }
}
