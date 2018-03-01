//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CamaraController.cs (01/03/2018)												\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Control de la camara										\\
// Fecha Mod:		01/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio
{
	/// <summary>
	/// <para>Control de la camara.</para>
	/// </summary>
	public class CamaraController : MonoBehaviour
	{
		#region Variables Activacion
		/// <summary>
		/// <para>Determina si se podra rotar horizontalmente.</para>
		/// </summary>
		public bool isHorizontal = false;													// Determina si se podra rotar horizontalmente
		/// <summary>
		/// <para>Determina si se podra rotar verticalmente.</para>
		/// </summary>
		public bool isVertical = false;														// Determina si se podra rotar verticalmente
		/// <summary>
		/// <para>Determina si se podra rotar globalmente.</para>
		/// </summary>
		public bool isGlobal = false;														// Determina si se podra rotar globalmente
		/// <summary>
		/// <para>Determina si se puede hacer zoom.</para>
		/// </summary>
		public bool isZoom = false;															// Determina si se puede hacer zoom
		/// <summary>
		/// <para>Determina si tendra autorotacion.</para>
		/// </summary>
		public bool isAutorotacion = false;													// Determina si tendra autorotacion
		#endregion

		#region Variables Publicas Autorotacion
		/// <summary>
		/// <para>Velocidad de rotacion de la camara.</para>
		/// </summary>
		public float velAutorotacion = 3f;                                                  // Velocidad de rotacion de la camara
		#endregion

		#region Variables Publicas Horizontal
		/// <summary>
		/// <para>Velocidad de rotacion horizontal.</para>
		/// </summary>
		public float velRotacionHori = 0.0f;												// Velocidad de rotacion horizontal
		/// <summary>
		/// <para>Velocidad de la deseleracion horizontal.</para>
		/// </summary>
		public float velLerpHori = 0.0f;                                                    // Velocidad de la deseleracion horizontal
		/// <summary>
		/// <para>Determina si se usara un axis del mouse diferente.</para>
		/// </summary>
		public bool customAxisHorizontal = false;											// Determina si se usara un axis del mouse diferente
		/// <summary>
		/// <para>El nombre del axis custom para horizontal.</para>
		/// </summary>
		public string customAxisMouse = string.Empty;                                       // El nombre del axis custom para horizontal
		#endregion

		#region Variables Publicas Vertical
		/// <summary>
		/// <para>Limite superior de la posicion de la camara.</para>
		/// </summary>
		public float limiteSuperior = 0.0f;													// Limite superior de la posicion de la camara
		/// <summary>
		/// <para>Limite inferior de la posicion de la camara.</para>
		/// </summary>
		public float limiteInferior = 0.0f;													// Limite inferior de la posicion de la camara
		/// <summary>
		/// <para>Umbral superior de la camara.</para>
		/// </summary>
		public float umbralSuperior = 0.0f;													// Umbral superior de la camara
		/// <summary>
		/// <para>Umbral inferior de la camara.</para>
		/// </summary>
		public float umbralInferior = 0.0f;													// Umbral inferior de la camara
		/// <summary>
		/// <para>Velocidad de movimiento de la camara verticalmente.</para>
		/// </summary>
		public float velMovimientoVert = 0.0f;												// Velocidad de movimiento de la camara verticalmente
		/// <summary>
		/// <para>Velocidad de rotacion de la camara verticalmente.</para>
		/// </summary>
		public float velRotacionVert = 0.0f;												// Velocidad de rotacion de la camara verticalmente
		/// <summary>
		/// <para>Velocidad de la deseleracion vertical.</para>
		/// </summary>
		public float velLerpVert = 0.0f;                                                    // Velocidad de la deseleracion vertical
		/// <summary>
		/// <para>Angulo maximo de inclinacion vertical.</para>
		/// </summary>
		public float anguloMaximo = 30.0f;													// Angulo maximo de inclinacion vertical
		/// <summary>
		/// <para>Angulo minimo de inclinacion vertical.</para>
		/// </summary>
		public float anguloMinimo = -30.0f;													// Angulo minimo de inclinacion vertical
		#endregion

		#region Variables Privadas Horizontal
		/// <summary>
		/// <para>Velocidad que mantiene la rotacion horizontal actual.</para>
		/// </summary>
		private float velocidadHorizontal = 0.0f;                                           // Velocidad que mantiene la rotacion horizontal actual
		/// <summary>
		/// <para>Temporizador para comprobar si el toque es una rotacion valida.</para>
		/// </summary>
		private float tempoHorizontal = 0.0f;												// Temporizador para comprobar si el toque es una rotacion valida
		/// <summary>
		/// <para>Contiene la info del axi x del mouse.</para>
		/// </summary>
		private float xAxiHori = 0.0f;														// Contiene la info del axi x del mouse
		/// <summary>
		/// <para>Contiene la info del ultimo touch.</para>
		/// </summary>
		private int ultimoTouchHori = 0;                                                    // Contiene la info del ultimo touch
		#endregion

		#region Variables Privadas Vertical
		/// <summary>
		/// <para>Velocidad que mantiene la rotacion vertical actual.</para>
		/// </summary>
		private float velocidadVertical = 0.0f;												// Velocidad que mantiene la rotacion vertical actual
		/// <summary>
		/// <para>Temporizador para comprobar si el toque es una rotacion valida.</para>
		/// </summary>
		private float tempoVertical = 0.0f;													// Temporizador para comprobar si el toque es una rotacion valida
		/// <summary>
		/// <para>Contiene la info del axi y del mouse.</para>
		/// </summary>
		private float yAxiVert = 0.0f;                                                      // Contiene la info del axi y del mouse
		/// <summary>
		/// <para>Rotacion actual de Y.</para>
		/// </summary>
		private float rotacionYActual = 0.0f;												// Rotacion actual de Y
		/// <summary>
		/// <para>Quaternion original.</para>
		/// </summary>
		private Quaternion rotOriginal;														// Quaternion original
		/// <summary>
		/// <para>Rotacion X original.</para>
		/// </summary>
		private float rotX = 0.0f;															// Rotacion X original
		/// <summary>
		/// <para>Rotacion Y original.</para>
		/// </summary>
		private float rotY = 0.0f;															// Rotacion Y original
		/// <summary>
		/// <para>Contiene la info del ultimo touch.</para>
		/// </summary>
		private int ultimoTouchVert = 0;                                                    // Contiene la info del ultimo touch
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="CamaraController"/>.</para>
		/// </summary>
		protected void Start()// Inicializador de CamaraController
		{
			#region Vertical
			if (isVertical)
			{
				rotOriginal = this.transform.localRotation;
				rotX = this.transform.localEulerAngles.x;
				rotY = this.transform.localEulerAngles.y;
			}
			#endregion
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="CamaraController"/>.</para>
		/// </summary>
		protected void Update()// Actualizador de CamaraController
		{
			#region Autorotacion
			if (isAutorotacion)
			{
				// Gira el objeto si el usuario no esta haciendo clic o tocando la pantalla
				if (!Input.GetMouseButton(0)) transform.Rotate(0.0f, velAutorotacion, 0.0f, Space.World);
			}
			#endregion

			#region Horizontal
			if (isHorizontal)
			{
				if (Input.touchCount < 2 && ultimoTouchHori < 2)
				{
					if (Input.touchCount == 0) ultimoTouchHori = 0;
					// Suma al temporizador cada vez que el usuario tiene el boton izquierdo del mouse/touch con un dedo en el dispositivo movil
					if (Input.GetMouseButton(0)) tempoHorizontal++;

					// Si el usuario retiene mas de 3 frames, registrar el eje x del mouse
					if (Input.GetMouseButton(0) && tempoHorizontal > 3)
					{
						tempoHorizontal++;
						// Comprobar el tipo de axis
						if (customAxisHorizontal)
						{
							xAxiHori = Input.GetAxis(customAxisMouse);
						}
						else
						{
							xAxiHori = Input.GetAxis("Mouse X");
						}
						
						velocidadHorizontal = xAxiHori;
					}
					else
					{
						// De lo contrario, el usuario ya no presiona el clic del mouse, comenzar a calcular la velocidad del lerp
						var i = Time.deltaTime * velLerpHori;
						velocidadHorizontal = Mathf.Lerp(velocidadHorizontal, 0, i);
					}

					// Resetear tempo
					if (Input.GetMouseButtonUp(0))
					{
						tempoHorizontal = 0;
					}
					// Rotar el objeto
					transform.Rotate(0.0f, velocidadHorizontal * velRotacionHori, 0.0f, Space.World);
				}
				else
				{
					ultimoTouchHori = Input.touchCount;
					velocidadHorizontal = 0;
				}
			}
			#endregion

			#region Vertical
			if (isVertical)
			{
				if (Input.touchCount < 2 && ultimoTouchVert < 2)
				{
					if (Input.touchCount == 0) ultimoTouchVert = 0;
					// Suma al temporizador cada vez que el usuario tiene el boton izquierdo del mouse/touch con un dedo en el dispositivo movil
					if (Input.GetMouseButton(0)) tempoVertical++;

					// Si el usuario retiene mas de 3 frames, registrar el eje x del mouse
					if (Input.GetMouseButton(0) && tempoVertical > 3)
					{
						// Invertir el eje y recibido, para crear un movimiento de eje inverso
						yAxiVert = -Input.GetAxis("Mouse Y");
						velocidadVertical = yAxiVert;
					}
					else
					{
						// De lo contrario, el usuario ya no presiona el clic del mouse, comenzar a calcular la velocidad del lerp
						var ix = Time.deltaTime * velLerpVert;
						velocidadVertical = Mathf.Lerp(velocidadVertical, 0, ix);
					}

					// Resetear tempo
					if (Input.GetMouseButtonUp(0))
					{
						tempoVertical = 0;
					}

					// Calcular el movimiento de la camara
					float limitY = Mathf.Clamp(transform.position.y + (velocidadVertical * velMovimientoVert), limiteInferior, limiteSuperior);

					transform.position = new Vector3(0,limitY,0);

					// Si la camara todavia esta dentro del limite, girar la camara tambien
					if (!(transform.position.y < umbralSuperior && transform.position.y > umbralInferior))
					{
						rotacionYActual += velocidadVertical * -velRotacionVert * 0.8f;
						if (transform.position.y > umbralSuperior)
						{
							rotacionYActual = ClampAngulo(rotacionYActual, -anguloMaximo, 1F);
						}
						else if (transform.position.y < umbralInferior)
						{
							rotacionYActual = ClampAngulo(rotacionYActual, 1F, -anguloMinimo);
						}
						Quaternion yQuaternion = Quaternion.AngleAxis(rotacionYActual, Vector3.left);
						transform.localRotation = rotOriginal * yQuaternion;
					}
				}
				else
				{
					ultimoTouchVert = Input.touchCount;
					velocidadVertical = 0;
				}
			}
			#endregion
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Interpola un angulo basandose en un minimo y maximo.</para>
		/// </summary>
		/// <param name="angulo">Angulo</param>
		/// <param name="min">Minimo</param>
		/// <param name="max">Maximo</param>
		/// <returns></returns>
		private float ClampAngulo(float angulo, float min, float max)// Interpola un angulo basandose en un minimo y maximo
		{
			if (angulo < -360) angulo += 360;
			if (angulo > 360) angulo -= 360;

			return Mathf.Clamp(angulo, min, max);
		}
		#endregion
	}
}
