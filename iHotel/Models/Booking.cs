//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIT5032_Assign1_v6.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;

    public partial class Booking
    {
        public int Id { get; set; }
        // public System.DateTime From_date { get; set; }
        //public System.DateTime To_date { get; set; }

        [Display(Name = "Checkin Date")]
        public System.DateTime From_date { get; set; }

        [Display(Name = "Checkout Date")]
        public System.DateTime To_date { get; set; }

        [Display(Name = "Adult Number")]
        public int Adult_Number { get; set; }

        [Display(Name = "Children Number")]
        public int Children_Number { get; set; }

        [Display(Name = "Room Type")]
        public int RoomInforId { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Customer Name")]
        public int CustomerId { get; set; }
    
        public virtual RoomInfor RoomInfor { get; set; }
        public virtual Customer Customer { get; set; }
        public object CustomerSet { get; internal set; }
        public object Rooms { get; internal set; }
        public object Customers { get; internal set; }

 
    }
}