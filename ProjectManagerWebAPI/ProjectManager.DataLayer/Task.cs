
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ProjectManager.DataLayer
{

using System;
    using System.Collections.Generic;
    
public partial class Task
{

    public int Task_ID { get; set; }

    public int Parent_ID { get; set; }

    public int Project_ID { get; set; }

    public string TaskName { get; set; }

    public System.DateTime Start_Date { get; set; }

    public System.DateTime End_Date { get; set; }

    public int Priority { get; set; }

    public bool Status { get; set; }



    public virtual ParentTask ParentTask { get; set; }

    public virtual Project Project { get; set; }

}

}
