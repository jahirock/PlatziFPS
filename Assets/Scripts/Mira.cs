using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
    public float Sensitivity = 100F;
    public Transform player1;
    float xRotation = 0F;
        
    void Start()
    {
        //Bloquea el cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Obtiene el movimiento del mouse en las dos coordenadas (negativo o positivo dependiendo la direccion).
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        //Le suma o le resta el movimiento dle mouse a la rotacion de la camara
        xRotation -= mouseY;
        //Se asegura de que xRotation solo pueda tener valores entre -80 y 70
        xRotation = Mathf.Clamp(xRotation, -80F, 70F);
        //Rota la camara en el eje X. (Osea que va a apuntar hacia arriba o hacia abajo)
        transform.localRotation = Quaternion.Euler(xRotation, 0F, 0F);
        //Rota al jugador(y la camara) en el eje Y (Osea mirar a los lados)
        player1.Rotate(Vector3.up * mouseX);
    }
}
