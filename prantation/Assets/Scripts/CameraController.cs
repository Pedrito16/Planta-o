using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform bounds;
    [SerializeField] float bordas;

    [Header("Camera Clamp Settings")]
    [SerializeField] Vector2 height;
    [SerializeField] Vector2 width;

    [Header("Camera Movement Settings")]
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] bool moveHorizontal;
    [SerializeField] bool moveVertical;
    [SerializeField] bool useFixedMovement;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 mousePosScreen = Camera.main.ScreenToWorldPoint(mousePos);
        //bordas = valor da área pro mouse poder se mexer
        //screen.height e width = valor da altura e largura da tela (valores de resolução)
        // se a posição do mouse y for maior que a altura (1200) menos borda (20) = 1180, ou seja, se o mouse estiver no 1180 pra cima, vai se mexer.
        //O mesmo se aplica para baixo: se a posição do mouse for menor que borda (20) mover para baixo.
        Vector2 direction = Vector2.zero;
        if(mousePos.x > Screen.width - bordas || mousePos.x < bordas || mousePos.y > Screen.height - bordas || mousePos.y < bordas)
        {
            if (mousePos.x > Screen.width - bordas && moveHorizontal) //direita
                direction += Vector2.right;
            else if (mousePos.x < bordas && moveHorizontal) //esquerda
                direction += Vector2.left;

            if (mousePos.y > Screen.height - bordas && moveVertical) //cima
                direction += Vector2.up;
            else if (mousePos.y < bordas && moveVertical) //baixo
                direction += Vector2.down;

            if (useFixedMovement)
                Camera.main.transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
            else
                Camera.main.transform.Translate(mousePosScreen.normalized * moveSpeed * Time.deltaTime);
        }
        else
        {
            return;
        }

        //Limitar a câmera
        Vector3 pos = Camera.main.transform.position;
        pos.x = Mathf.Clamp(pos.x, width.x, width.y);
        pos.y = Mathf.Clamp(pos.y, height.x, height.y);
        Camera.main.transform.position = pos;
    }
    private void OnDrawGizmos()
    {

    }
}
