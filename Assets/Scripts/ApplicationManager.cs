using UnityEngine;
using System.Collections;

public class ApplicationManager : Singleton<ApplicationManager>
{
	public void ApplicationQuit ()
	{
		Application.Quit ();
	}
}