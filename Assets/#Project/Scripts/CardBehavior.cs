using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Renderer))]
public class CardBehavior : MonoBehaviour
{
    // [SerializeField] private Vector3 scaleOnFocus = Vector3.one * 1.2f;
    const float SCALE = 1.2f;
    [SerializeField] private Vector3 scaleOnFocus;
    private Vector3 memoScale;
    private Color color;
    private int indexColor;
    private CardsManager manager;

    void OnMouseEnter()
    {
        // Debug.Log("Enter");
        memoScale = transform.localScale;
        scaleOnFocus = transform.localScale * SCALE;
        transform.localScale = scaleOnFocus;
    }
    void OnMouseExit()
    {
        // Debug.Log("Exit");
        transform.localScale = memoScale;
    }
    void OnMouseDown()
    {        
        ChangeColor(color);
    }
    public void Initialize(Color color, int indexColor, CardsManager manager)
    {
        this.color = color;
        this.indexColor = indexColor;
        this.manager = manager;

        // ChangeColor(color);

    }
    public void ChangeColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }

}
