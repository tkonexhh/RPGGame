﻿using UnityEngine; 
using System.Collections.Generic; 
using System.Collections; 
using GFrame; 
namespace Main.Game 
{ 
	public partial class TDApp_config 
	{
public string Id { get; set; }    //ID
	  public string _Id (){
		string value = Id;
		return value;
	}
	public string Value { get; set; }    //Value
	  public string _Value (){
		string value = Value;
		return value;
	}
		}
}