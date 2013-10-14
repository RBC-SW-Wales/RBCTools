﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using iTextSharp.text.pdf;

namespace RbcVolunteerApplications.Library
{
	public class S82Reader
	{
		
		#region Constructor 
		
		public S82Reader(string filePath)
		{
			this.FilePath = filePath;
			
			var reader = new PdfReader(this.FilePath);
			this.AcroFields = reader.AcroFields;
			reader = null;
		}
		
		#endregion
		
		#region Fields
		
		private string FilePath;
		
		private AcroFields AcroFields;
		
		#endregion
		
		#region Properties
		
		#endregion
		
		public VolunteerApplication BuildVolunteerApplication(Action<string> outputWarning, Func<string, string> queryCallback)
		{
			var volunteer = new VolunteerApplication();
			
			// Get Surname, FirstName and MiddleName
			
			string pdfValue = GetPdfValue("Text2");
			
			string lastName, firstName, middleNames = "";
			
			var names = pdfValue.Split(' ');
			if(names.Length == 3)
			{
				lastName = names[0];
				firstName = names[1];
				middleNames = names[2];
			}
			else if(names.Length == 2)
			{
				lastName = names[0];
				firstName = names[1];
			}
			else
			{
				outputWarning("I'm having problems understanding the 'names' field. I need your help. I'll open the file for you now.");
				
				var process = Process.Start(this.FilePath);
				
				lastName = queryCallback("Please can you tell me their 'Last Name'?");
				middleNames = queryCallback("Please can you tell me if they have any 'Middles Names'?");
				firstName = queryCallback("Please can you tell me their 'First Name'?");
				
				try
				{
					process.Kill();
				}
				catch (Exception){}
			}
			
			volunteer.LastName = lastName;
			volunteer.MiddleNames = middleNames;
			volunteer.FirstName = firstName;
			
			return volunteer;
		}
		
		private string GetPdfValue(string key)
		{
			return this.AcroFields.GetField(key).Trim().TrimInnerWhitespace();
		}
		
		public void ShowFields(Action<string> outputLine)
		{
			outputLine("Reading fields from " + this.FilePath);
			try
			{
				foreach(var entry in this.AcroFields.Fields)
				{
					var key = entry.Key;
					// Get the value for the key, and tidy it up a little.
					var val = this.AcroFields.GetField(entry.Key).Trim().TrimInnerWhitespace();
					
					outputLine("Field= \"" + key + "\", Value = " + val);
				}
			}
			catch (Exception ex)
			{
				outputLine("Error: " + ex.Message);
				throw;
			}
		}
	}
}
