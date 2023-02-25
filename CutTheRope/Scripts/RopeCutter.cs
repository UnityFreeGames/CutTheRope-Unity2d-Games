using UnityEngine;

public class RopeCutter : MonoBehaviour {
	
	Rigidbody2D rb;
	Camera Cam;

	void Start()
	{
       rb = GetComponent<Rigidbody2D>();
	   Cam = Camera.main;
	}



	void Update () {
		if (Input.GetMouseButton(0))
		{
			rb.position = Cam.ScreenToWorldPoint(Input.mousePosition);
			Invoke("visible_blade" , 0.05f);
			
			RaycastHit2D hit = Physics2D.Raycast(Cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if (hit.collider != null)
			{
				if (hit.collider.tag == "Link")
				{
					Destroy(hit.collider.gameObject);
				
					int count_child = hit.transform.parent.gameObject.transform.childCount;
					for (int i = 0 ; i < count_child-1; i++)
					{
						Destroy(hit.transform.parent.gameObject.transform.GetChild(i).gameObject , 2f);
					}
				}
			}
		}


		if(Input.GetMouseButtonDown(0))
		{
           gameObject.transform.GetChild(0).gameObject.SetActive(false);
		}
	}
	void visible_blade()
	{
       gameObject.transform.GetChild(0).gameObject.SetActive(true);
	}

	
}
