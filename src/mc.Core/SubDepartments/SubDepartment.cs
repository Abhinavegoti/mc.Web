using mc.Departments;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace mc.SubDepartments
{
    [Table("SubDepartments")]
    public class SubDepartment : Entity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public virtual string SubName { get; set; }

        public virtual int? Name { get; set; }

        [ForeignKey("Name")]
        public Department NameFk { get; set; }

    }
}