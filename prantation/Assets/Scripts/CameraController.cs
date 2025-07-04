using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform centerScreen;
    [SerializeField] float bordas;
    [SerializeField] Vector2 height;
    [SerializeField] Vector2 width;
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
        // se a posição do mouse y for maior que a altura (1200) menos borda (20) = 1180, ou seja, se o mouse estiver no 1180 pra cima, vai se mexer
        if (mousePos.y > Screen.height - bordas || mousePos.y < bordas || mousePos.x > Screen.width - bordas || mousePos.x < bordas)
        {
            Camera.main.transform.Translate(mousePosScreen.normalized * 3 * Time.deltaTime);
        } 
    }
    private void OnDrawGizmos()
    {
    }
}
