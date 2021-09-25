using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private RaycastHit2D _raycastHit;

    private Vector3 _moveDelta;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        _moveDelta = Vector3.zero;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        _moveDelta = new Vector3(x, y, 0.0f);

        if (_moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (_moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1 ,1);

        _raycastHit = Physics2D.BoxCast(transform.position,
            _boxCollider.size, 
            0, 
            new Vector2(0, _moveDelta.y), 
            Mathf.Abs(_moveDelta.y * Time.deltaTime),
            LayerMask.GetMask("Actor","Blocking"));

        if (_raycastHit.collider == null)
            transform.Translate(0, _moveDelta.y * Time.deltaTime, 0);
        
        _raycastHit = Physics2D.BoxCast(transform.position,
            _boxCollider.size, 
            0, 
            new Vector2(_moveDelta.x, 0), 
            Mathf.Abs(_moveDelta.x * Time.deltaTime),
            LayerMask.GetMask("Actor","Blocking"));

        if (_raycastHit.collider == null)
            transform.Translate(_moveDelta.x * Time.deltaTime, 0, 0);
    }
}
