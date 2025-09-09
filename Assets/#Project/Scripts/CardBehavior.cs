using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Renderer))]
public class CardBehavior : MonoBehaviour
{
    // [SerializeField] private Vector3 scaleOnFocus = Vector3.one * 1.2f;
    const float SCALE = 1.2f;
    [SerializeField] private Vector3 scaleOnFocus;
    [SerializeField] private float changeColorTime = 1f;
    private Vector3 memoScale;
    private Color color;
    [SerializeField] private Color baseColor = Color.gray;
    private int indexColor;
    private CardsManager manager;
    [field: SerializeField] public bool IsFaceUp { get; private set; }

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
        // Debug.Log("click");
        manager.CardIsClicked(this);

    }

    public void Initialize(Color color, int indexColor, CardsManager manager)
    {
        this.color = color;
        this.indexColor = indexColor;
        this.manager = manager;
        ChangeColor(baseColor);
        IsFaceUp = false;
    }
    private void ChangeColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }

    public void FaceUp()
    {
        ChangeColor(color);
        IsFaceUp = true;
    }
    public void FaceDown()
    {
        ChangeColor(baseColor);
        IsFaceUp = false;
    }



}
