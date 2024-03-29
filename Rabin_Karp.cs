﻿using System;
					
public class Program
{
	//Hash-function
	public static int Hash(string x)
	{
		int p = 31;
		int rez = 0;
		for (int i = 0; i < x.Length; i++)
		{
			rez+=(int)Math.Pow(p,x.Length-1-i)*(int)(x[i]);
		}
		return rez;
	}
	
	//Function of search (Rabin-Karp)
	public static string Rabina(string x, string s)
	{
		string nom = "";
		if (x.Length > s.Length) return nom;
		int xhash=Hash(x);
		int shash=Hash(s.Substring(0,x.Length));
		bool flag;
		int j;
		for (int i = 0; i < s.Length - x.Length; i++)
		{
			if (xhash == shash)
			{
				flag = true;
				j = 0;
				while ((flag == true) && (j < x.Length))
				{
					if (x[j] != s[i+j]) { flag = false; }
					j++;
				}
				if (flag == true)
				{
				    nom = nom+Convert.ToString(i) +	", ";
				}
			}
			else
			{
				shash = (shash-(int)Math.Pow(31, x.Length-1)*(int)(s[i]))*31+(int)(s[i+x.Length]);
			}
		}
		if (nom != "")
		{
			nom = nom.Substring(0, nom.Length - 2);
		}
		return nom;
	}
	
	public static void Main()
	{
		string d = Rabina("oleg", "dfhfhghghfgjg546456456j4564j6olegeredfgbhwe5h5olewnreretertlegwejkterjttolegnejktejkrtjeet");
		Console.WriteLine(d);
	}
}