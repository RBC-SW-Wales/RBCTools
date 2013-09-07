﻿
using System;
using System.Collections.Generic;

namespace RbcVolunteerApplications.Library
{
	/// <summary>
	///  A representation of the RBC Volunteer Application form.
	///  Based on S-82-E Bi 5/12
	/// </summary>
	public class VolunteerApplication
	{
		
		public VolunteerApplication(){}
		
		#region Properties
		
		public ApplicationKind ApplicationKind { get; set; }
		
		public FormOfServiceKinds FormsOfService { get; set; }
		
		public string LastName { get; set; }
		
		public string FirstName { get; set; }
		
		public string MiddleNames { get; set; }
		
		public GenderKind Gender { get; set; }
		
		public DateTime DateOfBirth { get; set; }
		
		public DateTime DateOfBaptism { get; set; }
		
		public string AddressStreetAndNumber { get; set; }
		
		public string AddressTown { get; set; }
		
		public string PostCode { get; set; }
		
		public string EmailAddress { get; set; }
		
		public string PhoneNumberHome { get; set; }
		
		public string PhoneNumberWork { get; set; }
		
		public string PhoneNumberMobile { get; set; }
		
		public PriviledgeKinds CurrentPriviledges { get; set; }
		
		#endregion
		
	}
	
	public enum ApplicationKind
	{
		NoneSpecified = 0,
		NewApplication = 1,
		UpdateOfPersonalData = 2
	}
	
	[Flags]
	public enum FormOfServiceKinds
	{
		NoneSpecified = 0,
		HallConstruction = 1,
		DisasterRelief = 2
	}
	
	public enum GenderKind
	{
		NoneSpecified = 0,
		Male = 1,
		Femail = 2
	}
	
	[Flags]
	public enum PriviledgeKinds
	{
		NoneSpecified = 0,
		Elder = 1,
		MinisterialServant = 2,
		RegularPioneer = 4
	}
}