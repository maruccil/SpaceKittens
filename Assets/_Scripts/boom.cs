using UnityEngine;
using System.Collections;

	public class boom : MonoBehaviour
	{
		public Animation anim;

		void Start()
		{
			// Walk backwards
			anim["explode"].speed = 5.0f;
		}

	
	// Update is called once per frame
	void Update () {
		
	}
}
