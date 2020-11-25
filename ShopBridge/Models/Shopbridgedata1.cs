using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ShopBridge.Models
{
    public class Shopbridgedata1
    {
        /// <summary>
        /// initialise properties
        /// </summary>
        public int product_id {  get; set; }    
       
        [DisplayName("Product Name")]
        public string product_name { get; set; }
        [DisplayName("Product Price")]
        public string product_price { get; set; }
        [DisplayName("Product Description")]
        public string product_description { get; set; }
            

    }
}