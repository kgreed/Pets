using System;
using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;
using DevExpress.Persistent.BaseImpl.EFCore.AuditTrail;
using System.ComponentModel.DataAnnotations;
using DevExpress.Persistent.Base;

namespace Pets.Module.BusinessObjects {

	public abstract class Pet
	{

		[Key] public int Id { get; set; }
		public string Name { get; set; }
		public bool? IsCat { get; set; }

	}
}
