//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCWork.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductListItems
    {
        public int ListItemID { get; set; }
        public Nullable<int> ProductListID { get; set; }
        public Nullable<int> ProductID { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual ProductLists ProductLists { get; set; }
    }
}
