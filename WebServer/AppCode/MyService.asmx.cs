using System;
using System.Web.Services;
 
[WebService (Namespace = "http://tempuri.org/MyService")] // tempuri.org is the default, you should change this
public class MyService
{
	[WebMethod]
	public int Add(int a, int b)
	{
		return a+b;
	}
}