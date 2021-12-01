using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public float distanceRaycast;
    public Color color1;
    public Color defaultColor;

    private Transform _selection;
    void Update()
    {
        if (_selection != null)
        {
            var selecetionRenderer = _selection.GetComponent<SpriteRenderer>();
            selecetionRenderer.color = defaultColor;
            _selection = null;
        }
        var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, transform.position);

        if (hit)
        {
            var selection = hit.transform;
            if (selection.CompareTag("Selectable"))
            {
                var selectionRenderer = selection.GetComponent<SpriteRenderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.color = color1;
                }

                _selection = selection;
            }
        }
    }
}
