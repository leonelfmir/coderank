using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Product
    {

        public int Id
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int Desc
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int Price
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }


    }
}