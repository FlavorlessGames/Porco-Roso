using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    //private Vector3 baseScale;
    //private Vector3 meshCenter;

    private Color baseColor;
    private Color highlightColor;

    private Renderer objRend;
    private Outline outline;

    [SerializeField] private Vector3 highlightScale = new Vector3(1.1f, 1.1f, 1.1f);
    [SerializeField] private float highlight = 0.2f;

    //[SerializeField] private AudioClip highlightSound;

    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();

        outline.enabled = false;

        Interactable interactable = GetComponent<Interactable>();
        interactable.OnHoverEvent += highlightHover;
        interactable.EndHoverEvent += highlightEnd;

        objRend = GetComponent<Renderer>();

        //baseScale = transform.localScale;

        baseColor = objRend.material.color;
        highlightColor = CalculateHighlight(baseColor, highlight);

        //CalculateMeshCenter();
    }

    //public void ScaleAround(Vector3 pivot, Vector3 newScale)
    //{
    //    Vector3 A = gameObject.transform.localPosition;
    //    Vector3 B = pivot;

    //    Vector3 C = A - B; // diff from object pivot to desired pivot/origin

    //    float RS = newScale.x / gameObject.transform.localScale.x; // relataive scale factor

    //    // calc final position post-scale
    //    Vector3 FP = B + C * RS;

    //    // finally, actually perform the scale/translation
    //    gameObject.transform.localScale = newScale;
    //    gameObject.transform.localPosition = FP;
    //}


    //void CalculateMeshCenter()
    //{
    //    MeshFilter meshFilter = GetComponent<MeshFilter>();

    //    if (meshFilter != null && meshFilter.mesh != null)
    //    {
    //        Vector3[] vertices = meshFilter.mesh.vertices;
    //        Vector3 sum = Vector3.zero;

    //        foreach (Vector3 vertex in vertices)
    //        {
    //            sum += vertex;
    //        }

    //        meshCenter = sum / vertices.Length;
    //    }

    //    else
    //    {
    //        Debug.LogError("NO MESH");
    //    }
    //}


    Color CalculateHighlight(Color original, float highlightAmount)
    {
        highlightAmount = Mathf.Clamp01(highlightAmount);

        return Color.Lerp(original, Color.white, highlightAmount);
    }

    private void highlightHover()
    { 
       // ScaleAround(meshCenter, highlightScale);

        objRend.material.color = highlightColor;

        outline.enabled = true;

        //AudioManager.instance.PlaySound(highlightSound);
    }

    private void highlightEnd()
    {
        Debug.Log("END");
      //  ScaleAround(meshCenter, baseScale);
        objRend.material.color = baseColor;

        outline.enabled = false;
    }
}









