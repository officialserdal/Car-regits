using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    [MetadataType(typeof(customerMetaData))]
    public partial  class customer
    {

        public class customerMetaData
        {
            [DisplayName("CustomerName")]
            public string custname { get; set; }
            [DisplayName("Address")]
            public string addres { get; set; }
            [DisplayName("Mobile")]
            public Nullable<int> mobile { get; set; }
        }
    }
}