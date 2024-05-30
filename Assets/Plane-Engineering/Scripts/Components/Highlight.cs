using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    private Vector3 baseScale;
    private Color baseColor;

    private Renderer objRend;

    [SerializeField] private Vector3 highlightScale = new Vector3(1.1f, 1.1f, 1.1f);
    [SerializeField] private Color highlightColor = Color.yellow;
    [SerializeField] private AudioClip highlightSound;

    // Start is called before the first frame update
    void Start()
    {
        Interactable interactable = GetComponent<Interactable>();
        interactable.OnHoverEvent += highlightHover;
        interactable.EndHoverEvent += highlightEnd;

        objRend = GetComponent<Renderer>();
        baseScale = transform.localScale;
        baseColor = objRend.material.color;
    }

    private void highlightHover()
    {
        
        transform.localScale = highlightScale;
        objRend.material.color = highlightColor;

        AudioManager.instance.PlaySound(highlightSound);
    }

    private void highlightEnd()
    {
        Debug.Log("END");
        transform.localScale = baseScale;
        objRend.material.color = baseColor;
    }
}
