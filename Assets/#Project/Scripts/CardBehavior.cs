using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Renderer))]
public class CardBehavior : MonoBehaviour
{
    // [SerializeField] private Vector3 scaleOnFocus = Vector3.one * 1.2f;
    const float SCALE = 1.2f;
    [SerializeField] private Vector3 scaleOnFocus;
    [SerializeField] private float changeColorTime = .5f;
    private Vector3 memoScale;
    private Color color;
    [SerializeField] private Color baseColor = Color.gray;
    public int IndexColor{ get; private set; }
    private CardsManager manager;
    public bool IsFaceUp { get; private set; }

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
        this.IndexColor = indexColor;
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
        // ChangeColor(color);
        StartCoroutine(ChangeColorwithLerp(color));
        IsFaceUp = true;
    }
    public void FaceDown(float delay = 0f)
    {
        // ChangeColor(baseColor);
        StartCoroutine(ChangeColorwithLerp(baseColor, delay));
        IsFaceUp = false;
    }
    public void Won()
    {
        // ChangeColor(baseColor);
        // GetComponent<Renderer>.destroy();
        IsFaceUp = true;

    }

    private IEnumerator ChangeColorwithLerp(Color color, float delay = 0f)
    {
        yield return new WaitForSeconds(delay);
        float chrono = 0f;
        Color startColor = GetComponent<Renderer>().material.color;

        while (chrono < changeColorTime)
        {
            chrono += Time.deltaTime;
            ChangeColor(Color.Lerp(startColor, color, chrono / changeColorTime));
            yield return new WaitForEndOfFrame();
            // yield return null;
        }
        ChangeColor(color);
    }

}
