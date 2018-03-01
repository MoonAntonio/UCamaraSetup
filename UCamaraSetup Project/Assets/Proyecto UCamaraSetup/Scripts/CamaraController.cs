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

		#region Variables Autorotacion
		/// <summary>
		/// <para>Velocidad de rotacion de la camara.</para>
		/// </summary>
		public float velAutorotacion = 3f;													// Velocidad de rotacion de la camara
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
		}
		#endregion

	}
}
