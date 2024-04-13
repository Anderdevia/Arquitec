using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

public class Class1
{
	public Class1()
	{
	private int id;
	 public int Id
	{
		get{ return id; }
		set { id = value; }
	}
	private string nombre;
	 
	public string Nombre
    {
        get { return nombre ; }
		set { nombre = value; }
	}
	private apellido;
	public string Apellido
	{
		get { return apellido; }
		set { apellido = value; }
	}

     private int edad;
	    public int Edad
	    {
		  get { return edad; }
		  set { edad = value; }
	    }

	private string cargo;
	  public string Cargo
	 {
		get { return cargo; }
		set { cargo = value; }
	 }

	private int sueldo;
	public int Sueldo
	{
		get { return sueldo; }
		set { sueldo = value; }
	}

}

