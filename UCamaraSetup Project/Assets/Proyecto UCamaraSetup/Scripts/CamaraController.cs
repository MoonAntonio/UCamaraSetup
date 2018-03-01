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
		public string customAxisMouse = string.Empty;										// El nombre del axis custom para horizontal
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
		private int ultimoTouchHori = 0;													// Contiene la info del ultimo touch
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
		}
		#endregion

	}
}
