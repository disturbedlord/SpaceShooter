using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class grenadeImpact : MonoBehaviour {
	public int vertexCount = 40;
	public float lineWidth = 0.2f;
	public float radius;
	public bool circleFillScreen;

	private LineRenderer lineRenderer;

	void Awake(){
		lineRenderer = GetComponent<LineRenderer>();
		setupCircle();
	}

	void setupCircle(){

		lineRenderer.widthMultiplier = lineWidth;

		if(circleFillScreen){
			radius = Vector3.Distance(Camera.main.ScreenToWorldPoint(new Vector3(0f , Camera.main.pixelRect.yMax , 0f)),
			Camera.main.ScreenToWorldPoint(new Vector3(0f , Camera.main.pixelRect.yMin , 0f))) * 0.5f - lineWidth;
		}

		float deltaTheta  = (2f * Mathf.PI) / vertexCount;
		float theta = 0f;

		lineRenderer.positionCount = vertexCount;
		for(int i = 0; i < lineRenderer.positionCount ; i++){
			Vector3 pos = new Vector3(radius * Mathf.Cos(theta) , radius * Mathf.Sin(theta) , 0f);
			lineRenderer.SetPosition(i , pos);
			theta += deltaTheta;
		}

	}

	private void OnDrawGizmos(){
		float deltaTheta = (2f * Mathf.PI) / 40f;
		float theta = 0f;

		Vector3 oldPos = Vector3.zero;
		// oldPos = new Vector3(1 , 2, 3);
		for(int i = 0; i < vertexCount + 1; i++){
			Vector3 pos = new Vector3(radius * Mathf.Cos(theta) + 5 , radius *Mathf.Sin(theta) + 5 , 0f);
			Gizmos.DrawLine(oldPos , transform.position + pos);
			oldPos = transform.position + pos;

			theta +=deltaTheta;
		}

	}
// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
