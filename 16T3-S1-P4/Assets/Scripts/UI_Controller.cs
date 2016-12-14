using UnityEngine;
using System.Collections;

public class UI_Controller : MonoBehaviour {

    LineRenderer _CursorLineRender;
    public GameObject Player;

	// Use this for initialization
	void Start () {
        _CursorLineRender = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        RenderLine(10);

	}

    void RenderLine(float MaxDist) {
        // Raycast to find mouse point
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float dist = 0;
        plane.Raycast(ray, out dist);
        Vector3 MousePos = ray.GetPoint(dist);

        Vector3[] Positions = new Vector3[2];
        Positions[0] = Player.transform.position;
        Positions[1] = MousePos;
        if (Vector3.Distance(Player.transform.position, MousePos) > MaxDist) {
            Vector3 nMousePos = Vector3.Normalize(MousePos);
            Positions[1] = nMousePos * MaxDist;
        }

        _CursorLineRender.SetPositions(Positions);
        _CursorLineRender.SetColors(Color.red, Color.yellow);
        _CursorLineRender.SetColors(Color.Lerp(Color.yellow, Color.red, Vector3.Distance(Positions[0], Positions[1]) / (MaxDist)), Color.Lerp(Color.red, Color.yellow, Vector3.Distance(Positions[0], Positions[1]) / (MaxDist)));
        _CursorLineRender.SetWidth(1, 0.25f);

        
    }

}
