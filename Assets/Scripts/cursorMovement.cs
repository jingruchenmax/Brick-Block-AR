using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;

public class cursorMovement : MonoBehaviour{

	public bool isDelete = false;

	RaycastHit hit;
	gridElement lastHit;
	// Use this for initialization
	void Start () 
	{

	}
	
	public void toggleConstructionMode()
    {
		isDelete = !isDelete;
	}
	// Update is called once per frame
	void Update () {

        if (Physics.Raycast(Camera.main.transform.position,
      Camera.main.transform.forward, out hit, 20f) && hit.collider.tag == "gridElement")
         //   if (CoreServices.InputSystem.EyeGazeProvider.HitInfo.collider.tag == "gridElement")
        {
            this.transform.position = hit.transform.position;
            lastHit = hit.collider.gameObject.GetComponent<gridElement>();
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }



	public void SetCurserButton(int input)
	{
		this.transform.localScale = new Vector3(0,0,0);
		coord coord = lastHit.GetCoord();
		int width = levelGenerator.instance.width;
		int height = levelGenerator.instance.height;
		int length = levelGenerator.instance.length;
		if (isDelete == true)
        {
			//remove gridElement
			if (coord.y > 0)
			{
				lastHit.SetDisable();
			}
		}
        else
        {
			switch (input)
			{
				case 0:
					//remove gridElement
					if (coord.y > 0)
					{
						lastHit.SetDisable();
					}
					break;
				case 1:
					//add X+
					if (coord.x < length - 1)
					{
						levelGenerator.instance.gridElements[coord.x + length * (coord.z + width * coord.y) + 1].SetEnable();
					}
					break;
				case 2:
					//add X-
					if (coord.x > 0)
					{
						levelGenerator.instance.gridElements[coord.x + length * (coord.z + width * coord.y) - 1].SetEnable();
					}
					break;
				case 3:
					//add Z+
					if (coord.z < width - 1)
					{
						levelGenerator.instance.gridElements[coord.x + length * (coord.z + 1 + width * coord.y)].SetEnable();
					}
					break;
				case 4:
					//add Z-
					if (coord.z > 0)
					{
						levelGenerator.instance.gridElements[coord.x + length * (coord.z - 1 + width * coord.y)].SetEnable();
					}
					break;
				case 5:
					//add Y+
					if (coord.y < height - 1)
					{
						levelGenerator.instance.gridElements[coord.x + length * (coord.z + width * (coord.y + 1))].SetEnable();
					}
					break;
			}
		}

	}
}