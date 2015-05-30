using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Model
{
   public  interface IModel
    {
        /// <summary>
        /// 自增ID
        /// </summary>
         int Id { get; set; }
    }
}
