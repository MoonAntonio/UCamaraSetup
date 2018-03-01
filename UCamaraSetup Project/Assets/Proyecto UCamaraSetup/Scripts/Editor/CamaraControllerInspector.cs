//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CamaraControllerInspector.cs (01/03/2018)									\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Inspector de CamaraController								\\
// Fecha Mod:		01/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEditor;
#endregion

namespace MoonAntonio
{
	/// <summary>
	/// <para>Inspector de CamaraController.</para>
	/// </summary>
	[CustomEditor(typeof(CamaraController))]
	public class CamaraControllerInspector : Editor
	{
		#region GUI
		public override void OnInspectorGUI()
		{
			#region Referencia
			CamaraController cc = (CamaraController)target;
			#endregion

			#region Setup
			EditorGUILayout.BeginVertical("box");

			EditorGUILayout.LabelField("Setup " + cc.gameObject.name);

			EditorGUILayout.BeginVertical("box");
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.Toggle("AutoRotacion", cc.isAutorotacion);
			if (cc.isAutorotacion)
			{
				if (GUILayout.Button("Desactivar AutoRotacion"))
				{
					cc.isAutorotacion = false;
				}
			}
			else
			{
				if (GUILayout.Button("Activar AutoRotacion"))
				{
					cc.isAutorotacion = true;
				}
			}
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.Toggle("Zoom", cc.isZoom);
			if (cc.isZoom)
			{
				if (GUILayout.Button("Desactivar Zoom"))
				{
					cc.isZoom = false;
				}
			}
			else
			{
				if (GUILayout.Button("Activar Zoom"))
				{
					cc.isZoom = true;
				}
			}
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginVertical("box");
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.Toggle("Horizontal", cc.isHorizontal);
			if (cc.isHorizontal)
			{
				if (GUILayout.Button("Desactivar Horizontal"))
				{
					cc.isHorizontal = false;
				}
			}
			else
			{
				if (GUILayout.Button("Activar Horizontal"))
				{
					cc.isHorizontal = true;
				}
			}
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.Toggle("Vertical", cc.isVertical);
			if (cc.isVertical)
			{
				if (GUILayout.Button("Desactivar Vertical"))
				{
					cc.isVertical = false;
				}
			}
			else
			{
				if (GUILayout.Button("Activar Vertical"))
				{
					cc.isVertical = true;
					cc.isGlobal = false;
				}
			}
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginVertical("box");
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.Toggle("Global", cc.isGlobal);
			if (cc.isGlobal)
			{
				if (GUILayout.Button("Desactivar Global"))
				{
					cc.isGlobal = false;
				}
			}
			else
			{
				if (GUILayout.Button("Activar Global"))
				{
					cc.isGlobal = true;
					cc.isVertical = false;
				}
			}
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.EndHorizontal();
			#endregion

			#region Config Auto
			EditorGUILayout.Space();

			if (cc.isAutorotacion)
			{
				EditorGUILayout.BeginVertical("box");

				EditorGUILayout.LabelField("Configuracion Autorotacion");

				EditorGUILayout.BeginVertical("box");
				cc.velAutorotacion = EditorGUILayout.Slider("Velocidad Rotacion",cc.velAutorotacion,0f,10f);
				EditorGUILayout.EndHorizontal();

				EditorGUILayout.EndHorizontal();
			}
			else
			{
				GUI.backgroundColor = Color.green;
				EditorGUILayout.HelpBox("Autorotacion desactivada!", MessageType.Info);
				GUI.backgroundColor = Color.white;
			}
			#endregion

			#region Config Zoom
			EditorGUILayout.Space();

			if (cc.isZoom)
			{
				EditorGUILayout.BeginVertical("box");

				EditorGUILayout.LabelField("Configuracion Zoom");

				EditorGUILayout.BeginVertical("box");
				cc.velZoom = EditorGUILayout.IntSlider("Velocidad Zoom", cc.velZoom, 0, 100);
				cc.maxDistanciaZoom = EditorGUILayout.IntSlider("Distancia Maxima Zoom", cc.maxDistanciaZoom, 0, 100);
				cc.minDistanciaZoom = EditorGUILayout.IntSlider("Distancia Minima Zoom", cc.minDistanciaZoom, 0, 100);
				cc.camara = (Camera)EditorGUILayout.ObjectField("Camara", cc.camara, typeof(Camera), true);
				EditorGUILayout.EndHorizontal();

				EditorGUILayout.EndHorizontal();
			}
			else
			{
				GUI.backgroundColor = Color.green;
				EditorGUILayout.HelpBox("Zoom desactivado!",MessageType.Info);
				GUI.backgroundColor = Color.white;
			}
			#endregion

			#region Config Horizontal
			EditorGUILayout.Space();

			if (cc.isHorizontal)
			{
				EditorGUILayout.BeginVertical("box");

				EditorGUILayout.LabelField("Configuracion Horizontal");

				EditorGUILayout.BeginVertical("box");
				cc.velRotacionHori = EditorGUILayout.Slider("Velocidad Rotacion", cc.velRotacionHori, 0f, 100f);
				cc.velLerpHori = EditorGUILayout.Slider("Velocidad Desaceleracion", cc.velLerpHori, 0f, 100f);
				EditorGUILayout.EndHorizontal();

				EditorGUILayout.EndHorizontal();
			}
			else
			{
				GUI.backgroundColor = Color.green;
				EditorGUILayout.HelpBox("Horizontal desactivado!", MessageType.Info);
				GUI.backgroundColor = Color.white;
			}
			#endregion

			#region Config Vertical
			EditorGUILayout.Space();

			if (cc.isVertical)
			{
				EditorGUILayout.BeginVertical("box");

				EditorGUILayout.LabelField("Configuracion Vertical");

				EditorGUILayout.BeginVertical("box");
				cc.velMovimientoVert = EditorGUILayout.Slider("Velocidad Movimiento", cc.velMovimientoVert, 0f, 100f);
				cc.velRotacionVert = EditorGUILayout.Slider("Velocidad Rotacion", cc.velRotacionVert, 0f, 100f);
				cc.velLerpVert = EditorGUILayout.Slider("Velocidad Desaceleracion", cc.velLerpVert, 0f, 100f);
				EditorGUILayout.EndHorizontal();

				EditorGUILayout.Space();

				EditorGUILayout.BeginVertical("box");
				cc.limiteSuperior = EditorGUILayout.Slider("Limite Superior", cc.limiteSuperior, 0f, 100f);
				cc.limiteInferior = EditorGUILayout.Slider("Limite Inferior", cc.limiteInferior, 0f, 100f);
				EditorGUILayout.EndHorizontal();

				EditorGUILayout.Space();

				EditorGUILayout.BeginVertical("box");
				cc.umbralSuperior = EditorGUILayout.Slider("Umbral Superior", cc.umbralSuperior, 0f, 100f);
				cc.umbralInferior = EditorGUILayout.Slider("Umbral Inferior", cc.umbralInferior, 0f, 100f);
				EditorGUILayout.EndHorizontal();

				EditorGUILayout.Space();

				EditorGUILayout.BeginVertical("box");
				cc.anguloMaximo = EditorGUILayout.Slider("Angulo Maximo", cc.anguloMaximo, 0f, 100f);
				cc.anguloMinimo = EditorGUILayout.Slider("Angulo Minimo", cc.anguloMinimo, 0f, 100f);
				EditorGUILayout.EndHorizontal();

				EditorGUILayout.EndHorizontal();
			}
			else
			{
				GUI.backgroundColor = Color.green;
				EditorGUILayout.HelpBox("Vertical desactivado!", MessageType.Info);
				GUI.backgroundColor = Color.white;
			}
			#endregion

			#region Config Global
			EditorGUILayout.Space();

			if (cc.isGlobal)
			{
				EditorGUILayout.BeginVertical("box");

				EditorGUILayout.LabelField("Configuracion Global");

				EditorGUILayout.BeginVertical("box");
				cc.velRotacionGlobal = EditorGUILayout.Slider("Velocidad Rotacion", cc.velRotacionGlobal, 0f, 100f);
				cc.velLerpGlobal = EditorGUILayout.Slider("Velocidad Desaceleracion", cc.velLerpGlobal, 0f, 100f);
				EditorGUILayout.EndHorizontal();

				EditorGUILayout.Space();

				EditorGUILayout.BeginVertical("box");
				cc.anguloMaxGlobal = EditorGUILayout.Slider("Angulo Maximo", cc.anguloMaxGlobal, 0f, 100f);
				cc.anguloMinGlobal = EditorGUILayout.Slider("Angulo Minimo", cc.anguloMinGlobal, 0f, 100f);
				EditorGUILayout.EndHorizontal();

				EditorGUILayout.EndHorizontal();
			}
			else
			{
				GUI.backgroundColor = Color.green;
				EditorGUILayout.HelpBox("Global desactivado!", MessageType.Info);
				GUI.backgroundColor = Color.white;
			}
			#endregion
		}
		#endregion
	}
}