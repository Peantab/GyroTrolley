using UnityEngine;
using System.Collections;

public class MathEquations {

	// Class for counting equations of :

	// accelaration (const);
	public static double a = 0.003; // Póki co niepotrzebne.

	// v(t) :
	public static float v_coef = 4f;
	public static float v(int sinceCol){
		return v_coef * Mathf.Log(sinceCol);
	}

	//theta(normalized_gyroscope_value)
	//public static double theta(double serialized){
	//	return serialized*Mathf.PI-Mathf.PI/2.0; 
}






	


